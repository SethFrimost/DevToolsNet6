using Microsoft.Extensions.DependencyInjection;

namespace DevToolsNet.WindowsApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();


        }
        private void frmMain_Shown(object sender, EventArgs e)
        {

        }
        private void tsmiGenerador_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetService<frmGenerador>();
            f.MdiParent = this;
            f.Show();
        }

        private void tsmiSqlRunner_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetService<frmSQLRunner>();
            f.MdiParent = this;
            f.Show();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetService<frmWinServices>();
            f.MdiParent = this;
            f.Show();
        }
        private void powerShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetService<frmPowerShell>();
            f.MdiParent = this;
            f.Show();
        }




    }
}