using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace DevToolsNet.WinFormsControlLibrary
{
    [DesignerCategory("ToolStrip"),ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    public class ToolStripPanelHosted : ToolStripControlHost
    {
        public ToolStripPanelHosted() : base(new Panel()) { }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public Panel Panel { get { return Control as Panel; } }

    }
}
