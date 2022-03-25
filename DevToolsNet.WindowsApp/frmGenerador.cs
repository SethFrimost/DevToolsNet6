using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WindowsApp
{
    public partial class frmGenerador : Form
    {
        IConfigurator configurator;

        public frmGenerador()
        {
            InitializeComponent();
        }

        private void tsbVerTabManual_CheckedChanged(object sender, EventArgs e)
        {
            if(tsbVerTabManual.Checked) tabManual.Show();
            else tabManual.Hide();
        }
    }
}
