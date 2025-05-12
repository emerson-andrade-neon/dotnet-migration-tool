using DotNetMigrationTooll.Actions;
using DotNetMigrationTooll.Runners;
using DotNetMigrationTooll.Serialization;
using DotNetMigrationTooll.Win.Feedbacks;
using DotNetMigrationTooll.Workflows;
using System.Diagnostics;
using System.Text;
using Activity = DotNetMigrationTooll.Workflows.Activity;

namespace DotNetMigrationTooll.Win;

public partial class WorkflowForm : Form, IWorkflowObserver
{
    private readonly Runner _runner;
    private readonly List<Workflow> _workflowSelection = [];
    private readonly List<IAction> _ignoredActions = [];
    private RunCondition _runCondition = RunCondition.All;
    public WorkflowForm()
    {
        InitializeComponent();

        _runner = SerializerExtensions.CreateFromJson(this);

        var options = Enum.GetValues<RunCondition>();
        lsbOptions.DataSource = options;
        lsbOptions.SelectedItem = RunCondition.All;

        foreach (var action in AppEnvironment.GetStandardActions())
        {
            ckbActions.Items.Add(new ActionCheckBoxItem(action), true);
        }
        HandleButtons(false);
        RefreshDataGrid();
    }

    private void RefreshDataGrid()
    {
        var dataSource = _runner.Workflows.Select(e => new WorkflowRow(e));
        if (dataSource.Any())
        {
            workflowsSource.DataSource = dataSource;
        }
        else
        {
            workflowsSource.DataSource = null;
        }

        workflowsSource.ResetBindings(false);
    }
    private void SaveJson()
    {
        try
        {
            _runner.Serializer();
        }
        catch
        {
            //no need to worry about
        }
    }

    private void HandleButtons(bool isRunning)
    {
        var enableButtonsNeedingData = !isRunning && _runner.Workflows.Any();

        btnLoad.Enabled = !isRunning;

        btnExecuteAll.Enabled =
        btnExecuteSelection.Enabled =
        btnRemove.Enabled = enableButtonsNeedingData;
    }

    private bool HandleSelection()
    {
        this._workflowSelection.Clear();
        var selRowIndexes = this.dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Index);

        if (!selRowIndexes.Any())
        {
            return false;
        }

        foreach (var selRowIndex in selRowIndexes)
        {
            var row = (WorkflowRow)workflowsSource[selRowIndex];
            _workflowSelection.Add(row.Executor);
        }
        return true;
    }

    private void HandleRunnerOptions()
    {
        _ignoredActions.Clear();
        var i = 0;
        foreach (var item in ckbActions.Items.Cast<ActionCheckBoxItem>())
        {
            if (!ckbActions.GetItemChecked(i))
            {
                _ignoredActions.Add(item.Action);
            }
            i++;
        }
        _runCondition = (RunCondition)lsbOptions.SelectedValue;
    }

    #region buttons events
    private void btnLoad_Click(object sender, EventArgs e)
    {
        var repositories = RepositoryLoadDialog.ShowModal();
        if (repositories.Any())
        {
            _runner.AddRepositories(repositories);

            RefreshDataGrid();
            HandleButtons(false);
        }
        SaveJson();
    }

    private void btnExecuteAll_ClickAsync(object sender, EventArgs e)
    {
        HandleRunnerOptions();
        this._workflowSelection.Clear();
        RunWorker();
    }

    private void btnExecuteSelection_Click(object sender, EventArgs e)
    {
        ExecuteSelection();
    }

    private void ExecuteSelection()
    {
        if (HandleSelection())
        {
            HandleRunnerOptions();
            RunWorker();
        }
    }

    private void btnRemove_Click(object sender, EventArgs e)
    {
        if (HandleSelection())
        {
            if (MessageBox.Show($"Do you really want to delete the {_workflowSelection.Count} selected item(s)?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.No)
            {
                return;
            }
            _runner.Remove(_workflowSelection);
            RefreshDataGrid();
            HandleButtons(false);
            SaveJson();
        }
    }

    #endregion

    #region backgroundWorker  
    private void RunWorker()
    {
        txbOutput.Clear();
        HandleButtons(true);
        backgroundWorker.RunWorkerAsync();
    }
    private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        var options = new RunnerOptions(_runCondition, _ignoredActions);
        var task = _workflowSelection.Any() ?
            _runner.RunSelection(options, _workflowSelection) :
            _runner.Run(options);
        Task.WaitAll(task);
    }
    private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        if (e.UserState is FeedBack feedBack)
        {
            txbOutput.AppendFeedback(feedBack);
            RefreshDataGrid();
        }
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
    {
        HandleButtons(false);
    }
    #endregion

    #region dataGridViewEvents
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var col = dataGridView1.Columns[e.ColumnIndex];

        if (col is DataGridViewButtonColumn colBtn)
        {
            e.Value = colBtn.Text;
        }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (workflowsSource.Count < e.RowIndex || e.RowIndex < 0)
        {
            return;
        }

        var row = (WorkflowRow)workflowsSource[e.RowIndex];
        if (e.ColumnIndex == colOpenFolderBtn.Index)
        {
            Process.Start("explorer", row.Executor.Context.LocalPath);
        }
        if (e.ColumnIndex == colShowLogBtn.Index)
        {
            LogForm.ShowLog(row.Executor);
        }

        if (e.ColumnIndex == colTryAgainBtn.Index && btnExecuteSelection.Enabled)
        {
            dataGridView1.ClearSelection();
            dataGridView1.Rows[e.RowIndex].Selected = true;
            ExecuteSelection();
        }

    }

    private void btnOpenWokerFolder_Click(object sender, EventArgs e)
    {
        Process.Start("explorer", AppEnvironment.RepoPath);
    }

    #endregion

    #region IExecutorObserver
    void IWorkflowObserver.Begin(Context context, Workflow workflow)
    {
        backgroundWorker.SendFeedback(FeedbackKind.None, $"===================================={System.Environment.NewLine}{context.RepoName}");
    }

    void IWorkflowObserver.BeforeExecution(Context context, Activity activity)
    {
        backgroundWorker.SendFeedback(FeedbackKind.None, ($"{activity.Action.Name}: Executing ..."));
    }

    void IWorkflowObserver.AfterExecution(Context context, Activity activity)
    {
        backgroundWorker.SendFeedback(activity.GetFeedbackKind(), $"{activity.Action.Name}: Status: {activity.Status}{Environment.NewLine}{activity.Message}");
    }

    void IWorkflowObserver.End(Context context, Workflow workflow)
    {
        var message = new StringBuilder();

        message.AppendLine($"====================================");
        message.AppendLine($"Current Action: {workflow.CurrentAction.Name}");
        message.AppendLine($"Current Status: {workflow.CurrentStatus.ToString()}");

        message.AppendLine($"====================================");

        backgroundWorker.SendFeedback(workflow.CurrentStatus.ToFeedbackKind(), message.ToString());

        SaveJson();

    }
    #endregion
}
