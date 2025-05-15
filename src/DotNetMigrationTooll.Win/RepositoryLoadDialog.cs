namespace DotNetMigrationTooll.Win;
public partial class RepositoryLoadDialog : Form
{
    private RepositoryLoadDialog()
    {
        InitializeComponent();
    }

    public IEnumerable<string> Repositories => txbRepositories.Lines;

    public static IEnumerable<string> ShowModal()
    {
        using (var dialog = new RepositoryLoadDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.Repositories;
            }
            return [];
        }
    }
}
