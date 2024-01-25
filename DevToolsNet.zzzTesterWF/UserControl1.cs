using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevToolsNet.Extensions;

namespace DevToolsNet.zzzTesterWF
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var cp = new ColorDialog();
            Color c1, c2, cr;
            c1 = p1a.BackColor;
            c2 = p1b.BackColor;
            if (cp.ShowDialog() == DialogResult.OK)
            {
                c1 = cp.Color;
            }
            if (cp.ShowDialog() == DialogResult.OK)
            {
                c2 = cp.Color;
            }


            p1a.BackColor = c1;
            p1b.BackColor = c2;
            p1r.BackColor = c1.Blend(c2, tbMix.Value / 100d);

        }

        private void tbMix_ValueChanged(object sender, EventArgs e)
        {
            p1r.BackColor = p1a.BackColor.Blend(p1b.BackColor, tbMix.Value / 100d);
        }
    }
}
