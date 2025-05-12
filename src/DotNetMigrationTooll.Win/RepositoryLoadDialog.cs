using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
