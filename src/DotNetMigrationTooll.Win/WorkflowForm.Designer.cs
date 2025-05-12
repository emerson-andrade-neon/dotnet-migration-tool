namespace DotNetMigrationTooll.Win;

partial class WorkflowForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        var dataGridViewCellStyle1 = new DataGridViewCellStyle();
        var dataGridViewCellStyle2 = new DataGridViewCellStyle();
        btnExecuteSelection = new Button();
        btnRemove = new Button();
        btnLoad = new Button();
        btnExecuteAll = new Button();
        ckbActions = new CheckedListBox();
        lbActions = new Label();
        lsbOptions = new ListBox();
        label1 = new Label();
        splitContainer1 = new SplitContainer();
        dataGridView1 = new DataGridView();
        repositoryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        currentActionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        currentStatusDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        colShowLogBtn = new DataGridViewButtonColumn();
        colTryAgainBtn = new DataGridViewButtonColumn();
        colOpenFolderBtn = new DataGridViewButtonColumn();
        workflowsSource = new BindingSource(components);
        txbOutput = new RichTextBox();
        backgroundWorker = new System.ComponentModel.BackgroundWorker();
        toolbar = new FlowLayoutPanel();
        panel2 = new Panel();
        panel3 = new Panel();
        btnOpenWokerFolder = new Button();
        ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
        splitContainer1.Panel1.SuspendLayout();
        splitContainer1.Panel2.SuspendLayout();
        splitContainer1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)workflowsSource).BeginInit();
        toolbar.SuspendLayout();
        panel2.SuspendLayout();
        panel3.SuspendLayout();
        SuspendLayout();
        // 
        // btnExecuteSelection
        // 
        btnExecuteSelection.BackColor = SystemColors.Control;
        btnExecuteSelection.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        btnExecuteSelection.FlatStyle = FlatStyle.Flat;
        btnExecuteSelection.Font = new Font("Segoe UI", 9F);
        btnExecuteSelection.ForeColor = SystemColors.ControlText;
        btnExecuteSelection.Location = new Point(870, 55);
        btnExecuteSelection.Name = "btnExecuteSelection";
        btnExecuteSelection.Size = new Size(132, 41);
        btnExecuteSelection.TabIndex = 3;
        btnExecuteSelection.Text = "Execute Selection";
        btnExecuteSelection.UseVisualStyleBackColor = false;
        btnExecuteSelection.Click += btnExecuteSelection_Click;
        // 
        // btnRemove
        // 
        btnRemove.BackColor = Color.Red;
        btnRemove.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        btnRemove.FlatStyle = FlatStyle.Flat;
        btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnRemove.ForeColor = Color.White;
        btnRemove.Location = new Point(870, 3);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(132, 46);
        btnRemove.TabIndex = 3;
        btnRemove.Text = "Delete Selection";
        btnRemove.UseVisualStyleBackColor = false;
        btnRemove.Click += btnRemove_Click;
        // 
        // btnLoad
        // 
        btnLoad.BackColor = Color.ForestGreen;
        btnLoad.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        btnLoad.FlatStyle = FlatStyle.Flat;
        btnLoad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnLoad.ForeColor = Color.White;
        btnLoad.Location = new Point(3, 3);
        btnLoad.Name = "btnLoad";
        btnLoad.Size = new Size(107, 94);
        btnLoad.TabIndex = 3;
        btnLoad.Text = "Load";
        btnLoad.UseVisualStyleBackColor = false;
        btnLoad.Click += btnLoad_Click;
        // 
        // btnExecuteAll
        // 
        btnExecuteAll.BackColor = SystemColors.Control;
        btnExecuteAll.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        btnExecuteAll.FlatStyle = FlatStyle.Flat;
        btnExecuteAll.Font = new Font("Segoe UI", 9F);
        btnExecuteAll.ForeColor = SystemColors.ControlText;
        btnExecuteAll.Location = new Point(761, 3);
        btnExecuteAll.Name = "btnExecuteAll";
        btnExecuteAll.Size = new Size(103, 94);
        btnExecuteAll.TabIndex = 3;
        btnExecuteAll.Text = "Execute All";
        btnExecuteAll.UseVisualStyleBackColor = false;
        btnExecuteAll.Click += btnExecuteAll_ClickAsync;
        // 
        // ckbActions
        // 
        ckbActions.CheckOnClick = true;
        ckbActions.Dock = DockStyle.Fill;
        ckbActions.FormattingEnabled = true;
        ckbActions.IntegralHeight = false;
        ckbActions.Location = new Point(5, 25);
        ckbActions.MultiColumn = true;
        ckbActions.Name = "ckbActions";
        ckbActions.Size = new Size(473, 69);
        ckbActions.TabIndex = 2;
        // 
        // lbActions
        // 
        lbActions.AutoSize = true;
        lbActions.Dock = DockStyle.Top;
        lbActions.Location = new Point(5, 5);
        lbActions.Name = "lbActions";
        lbActions.Padding = new Padding(0, 0, 0, 5);
        lbActions.Size = new Size(50, 20);
        lbActions.TabIndex = 0;
        lbActions.Text = "Actions:";
        // 
        // lsbOptions
        // 
        lsbOptions.Dock = DockStyle.Fill;
        lsbOptions.FormattingEnabled = true;
        lsbOptions.ItemHeight = 15;
        lsbOptions.Location = new Point(5, 25);
        lsbOptions.Name = "lsbOptions";
        lsbOptions.Size = new Size(140, 69);
        lsbOptions.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = DockStyle.Top;
        label1.Location = new Point(5, 5);
        label1.Name = "label1";
        label1.Padding = new Padding(0, 0, 0, 5);
        label1.Size = new Size(63, 20);
        label1.TabIndex = 0;
        label1.Text = "Condition:";
        // 
        // splitContainer1
        // 
        splitContainer1.Dock = DockStyle.Fill;
        splitContainer1.Location = new Point(5, 112);
        splitContainer1.Name = "splitContainer1";
        splitContainer1.Orientation = Orientation.Horizontal;
        // 
        // splitContainer1.Panel1
        // 
        splitContainer1.Panel1.Controls.Add(dataGridView1);
        // 
        // splitContainer1.Panel2
        // 
        splitContainer1.Panel2.Controls.Add(txbOutput);
        splitContainer1.Size = new Size(1270, 519);
        splitContainer1.SplitterDistance = 257;
        splitContainer1.TabIndex = 2;
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.AutoGenerateColumns = false;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        dataGridView1.BackgroundColor = SystemColors.Control;
        dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
        dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { repositoryDataGridViewTextBoxColumn, currentActionDataGridViewTextBoxColumn, currentStatusDataGridViewTextBoxColumn, colShowLogBtn, colTryAgainBtn, colOpenFolderBtn });
        dataGridView1.DataSource = workflowsSource;
        dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = SystemColors.Window;
        dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
        dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle2.SelectionBackColor = Color.DimGray;
        dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
        dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Margin = new Padding(10);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.RowTemplate.ReadOnly = true;
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dataGridView1.Size = new Size(1270, 257);
        dataGridView1.TabIndex = 4;
        dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        dataGridView1.CellFormatting += dataGridView1_CellFormatting;
        // 
        // repositoryDataGridViewTextBoxColumn
        // 
        repositoryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        repositoryDataGridViewTextBoxColumn.DataPropertyName = "Repository";
        repositoryDataGridViewTextBoxColumn.HeaderText = "Repository";
        repositoryDataGridViewTextBoxColumn.Name = "repositoryDataGridViewTextBoxColumn";
        repositoryDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // currentActionDataGridViewTextBoxColumn
        // 
        currentActionDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        currentActionDataGridViewTextBoxColumn.DataPropertyName = "CurrentAction";
        currentActionDataGridViewTextBoxColumn.HeaderText = "CurrentAction";
        currentActionDataGridViewTextBoxColumn.MinimumWidth = 120;
        currentActionDataGridViewTextBoxColumn.Name = "currentActionDataGridViewTextBoxColumn";
        currentActionDataGridViewTextBoxColumn.ReadOnly = true;
        currentActionDataGridViewTextBoxColumn.Width = 120;
        // 
        // currentStatusDataGridViewTextBoxColumn
        // 
        currentStatusDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        currentStatusDataGridViewTextBoxColumn.DataPropertyName = "CurrentStatus";
        currentStatusDataGridViewTextBoxColumn.HeaderText = "CurrentStatus";
        currentStatusDataGridViewTextBoxColumn.MinimumWidth = 120;
        currentStatusDataGridViewTextBoxColumn.Name = "currentStatusDataGridViewTextBoxColumn";
        currentStatusDataGridViewTextBoxColumn.ReadOnly = true;
        currentStatusDataGridViewTextBoxColumn.Width = 120;
        // 
        // colShowLogBtn
        // 
        colShowLogBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        colShowLogBtn.HeaderText = "";
        colShowLogBtn.MinimumWidth = 75;
        colShowLogBtn.Name = "colShowLogBtn";
        colShowLogBtn.ReadOnly = true;
        colShowLogBtn.Text = "Show Log";
        colShowLogBtn.Width = 75;
        // 
        // colTryAgainBtn
        // 
        colTryAgainBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        colTryAgainBtn.DataPropertyName = "Repository";
        colTryAgainBtn.HeaderText = "";
        colTryAgainBtn.MinimumWidth = 75;
        colTryAgainBtn.Name = "colTryAgainBtn";
        colTryAgainBtn.ReadOnly = true;
        colTryAgainBtn.Text = "Try Again";
        colTryAgainBtn.Width = 75;
        // 
        // colOpenFolderBtn
        // 
        colOpenFolderBtn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        colOpenFolderBtn.DataPropertyName = "Repository";
        colOpenFolderBtn.HeaderText = "";
        colOpenFolderBtn.MinimumWidth = 75;
        colOpenFolderBtn.Name = "colOpenFolderBtn";
        colOpenFolderBtn.ReadOnly = true;
        colOpenFolderBtn.Text = "Open Folder";
        colOpenFolderBtn.Width = 75;
        // 
        // workflowsSource
        // 
        workflowsSource.DataSource = typeof(WorkflowRow);
        // 
        // txbOutput
        // 
        txbOutput.BackColor = Color.White;
        txbOutput.Dock = DockStyle.Fill;
        txbOutput.Location = new Point(0, 0);
        txbOutput.Margin = new Padding(10);
        txbOutput.Name = "txbOutput";
        txbOutput.ReadOnly = true;
        txbOutput.Size = new Size(1270, 258);
        txbOutput.TabIndex = 2;
        txbOutput.Text = "";
        // 
        // backgroundWorker
        // 
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.WorkerSupportsCancellation = true;
        backgroundWorker.DoWork += backgroundWorker_DoWork;
        backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        // 
        // toolbar
        // 
        toolbar.AutoSize = true;
        toolbar.BorderStyle = BorderStyle.FixedSingle;
        toolbar.Controls.Add(btnLoad);
        toolbar.Controls.Add(panel2);
        toolbar.Controls.Add(panel3);
        toolbar.Controls.Add(btnExecuteAll);
        toolbar.Controls.Add(btnRemove);
        toolbar.Controls.Add(btnExecuteSelection);
        toolbar.Controls.Add(btnOpenWokerFolder);
        toolbar.Dock = DockStyle.Top;
        toolbar.FlowDirection = FlowDirection.TopDown;
        toolbar.Location = new Point(5, 5);
        toolbar.Name = "toolbar";
        toolbar.Size = new Size(1270, 107);
        toolbar.TabIndex = 3;
        // 
        // panel2
        // 
        panel2.Controls.Add(lsbOptions);
        panel2.Controls.Add(label1);
        panel2.Location = new Point(116, 3);
        panel2.Name = "panel2";
        panel2.Padding = new Padding(5);
        panel2.Size = new Size(150, 99);
        panel2.TabIndex = 0;
        // 
        // panel3
        // 
        panel3.Controls.Add(ckbActions);
        panel3.Controls.Add(lbActions);
        panel3.Location = new Point(272, 3);
        panel3.Name = "panel3";
        panel3.Padding = new Padding(5);
        panel3.Size = new Size(483, 99);
        panel3.TabIndex = 1;
        // 
        // btnOpenWokerFolder
        // 
        btnOpenWokerFolder.BackColor = SystemColors.Control;
        btnOpenWokerFolder.FlatAppearance.BorderColor = SystemColors.ControlDarkDark;
        btnOpenWokerFolder.FlatStyle = FlatStyle.Flat;
        btnOpenWokerFolder.Font = new Font("Segoe UI", 9F);
        btnOpenWokerFolder.ForeColor = SystemColors.ControlText;
        btnOpenWokerFolder.Location = new Point(1008, 3);
        btnOpenWokerFolder.Name = "btnOpenWokerFolder";
        btnOpenWokerFolder.Size = new Size(132, 41);
        btnOpenWokerFolder.TabIndex = 3;
        btnOpenWokerFolder.Text = "Open Worker Folder";
        btnOpenWokerFolder.UseVisualStyleBackColor = false;
        btnOpenWokerFolder.Click += btnOpenWokerFolder_Click;
        // 
        // WorkflowForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1280, 636);
        Controls.Add(splitContainer1);
        Controls.Add(toolbar);
        Name = "WorkflowForm";
        Padding = new Padding(5);
        Text = "Dotnet Migration Tool";
        splitContainer1.Panel1.ResumeLayout(false);
        splitContainer1.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
        splitContainer1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)workflowsSource).EndInit();
        toolbar.ResumeLayout(false);
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        panel3.ResumeLayout(false);
        panel3.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private CheckedListBox ckbActions;
    private Label lbActions;
    private ListBox lsbOptions;
    private Label label1;
    private Button btnExecuteSelection;
    private Button btnLoad;
    private Button btnExecuteAll;
    private SplitContainer splitContainer1;
    private DataGridView dataGridView1;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private BindingSource workflowsSource;
    private RichTextBox txbOutput;
    private Button btnRemove;
    private FlowLayoutPanel toolbar;
    private Panel panel2;
    private Panel panel3;
    private DataGridViewTextBoxColumn repositoryDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn currentActionDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn currentStatusDataGridViewTextBoxColumn;
    private DataGridViewButtonColumn colShowLogBtn;
    private DataGridViewButtonColumn colTryAgainBtn;
    private DataGridViewButtonColumn colOpenFolderBtn;
    private Button btnOpenWokerFolder;
}
