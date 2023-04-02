using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevToolsNet.WinFormsControlLibrary.Dialogs
{
    public partial class dlgText : Form
    {
        public string ResultText => txtRes.Text;

        public dlgText()
        {
            InitializeComponent();
        }

        public dlgText(string defaultText) : this()
        {
            txtRes.Text = defaultText;
        }

        protected new void Show() => base.Show();
        protected new void Show(IWin32Window? owner) => base.Show(owner);
    }
}
