using DotNetMigrationTooll.Win.Feedbacks;
using System.Text;
using DotNetMigrationTooll.Workflows;

namespace DotNetMigrationTooll.Win;
public partial class LogForm : Form
{
    private readonly Workflow _executor;

    public LogForm(Workflow executor)
    {
        _executor = executor;
        InitializeComponent();
        Refresh();
        _executor = executor;
    }

    public static void ShowLog(Workflow executor)
    {

        var frm = new LogForm(executor);
        frm.Show();
    }

    private void Refresh()
    {
        txbOutput.Clear();
        txbOutput.AppendFeedback(new(FeedbackKind.Success, "teste"));

        this.Text = _executor.Context.RepoName;

        this.txbOutput.AppendFeedback(new(FeedbackKind.None, _executor.Context.ToString()));

        foreach (var execution in _executor.Activities)
        {
            var kind = execution.GetFeedbackKind();

            var message = new StringBuilder();

            message.AppendLine($"====> {execution.Action.Name}: {execution.Status}");
            message.AppendLine(execution.Message);
            message.AppendLine("=====>");

            this.txbOutput.AppendFeedback(new(kind, message.ToString()));
        }

    }

}
