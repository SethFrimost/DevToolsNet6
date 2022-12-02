using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace DevToolsNet.WinFormsControlLibrary.Style
{
    public class StyleManager : IStyleManager
    {
        List<Style> Styles = new List<Style>();
        public string Active { get; set; }

        public void AplyStyleForm(Form frm, Style? style = null)
        {
            if (style == null) style = Styles.Find(x => x.Name == Active);
            if (style != null)
            {
                frm.BackColor = style.BackgroundColor;
                frm.ForeColor = style.ForeColor;

                foreach (Control c in frm.Controls) AplyStyleControl(c, style);
            }
        }

        public void AplyStyleControl(Control c, Style? style = null)
        {
            if (style == null) style = Styles.Find(x => x.Name == Active);
            if (style != null)
            {
                c.BackColor = style.BackgroundColor;
                c.ForeColor = style.ForeColor;
            }

            foreach (Control ch in c.Controls) AplyStyleControl(ch, style);
        }

    }
}
