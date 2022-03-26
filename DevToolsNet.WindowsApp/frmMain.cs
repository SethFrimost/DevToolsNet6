using Microsoft.Extensions.DependencyInjection;

namespace DevToolsNet.WindowsApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();


        }

        private void tsmiGenerador_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetService<frmGenerador>();
            f.MdiParent = this;
            f.Show();
        }
    }
}