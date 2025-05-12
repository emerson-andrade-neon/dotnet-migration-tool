namespace DotNetMigrationTooll.Win;

partial class RepositoryLoadDialog
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panel1 = new Panel();
        btnOk = new Button();
        btnCancel = new Button();
        txbRepositories = new TextBox();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Controls.Add(btnOk);
        panel1.Controls.Add(btnCancel);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(5, 274);
        panel1.Name = "panel1";
        panel1.Padding = new Padding(5);
        panel1.Size = new Size(535, 54);
        panel1.TabIndex = 0;
        // 
        // btnOk
        // 
        btnOk.DialogResult = DialogResult.OK;
        btnOk.Dock = DockStyle.Right;
        btnOk.Location = new Point(266, 5);
        btnOk.Name = "btnOk";
        btnOk.Size = new Size(132, 44);
        btnOk.TabIndex = 1;
        btnOk.Text = "Ok";
        btnOk.UseVisualStyleBackColor = false;
        // 
        // btnCancel
        // 
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Dock = DockStyle.Right;
        btnCancel.Location = new Point(398, 5);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(132, 44);
        btnCancel.TabIndex = 0;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = false;
        // 
        // txbRepositories
        // 
        txbRepositories.Dock = DockStyle.Fill;
        txbRepositories.Location = new Point(5, 5);
        txbRepositories.Multiline = true;
        txbRepositories.Name = "txbRepositories";
        txbRepositories.Size = new Size(535, 269);
        txbRepositories.TabIndex = 1;
        // 
        // RepositoryLoadDialog
        // 
        AcceptButton = btnOk;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(545, 333);
        Controls.Add(txbRepositories);
        Controls.Add(panel1);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "RepositoryLoadDialog";
        Padding = new Padding(5);
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Load Repositories";
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Panel panel1;
    private Button btnOk;
    private Button btnCancel;
    private TextBox txbRepositories;
}