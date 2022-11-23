using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace DevToolsNet.WinFormsControlLibrary
{
    [DesignerCategory("ToolStrip"),ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    //[ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip | ToolStripItemDesignerAvailability.ToolStrip | ToolStripItemDesignerAvailability.ContextMenuStrip)]
    public class ToolStripTextHosted : ToolStripControlHost
    {
        public ToolStripTextHosted() : base(new TextBox()) { }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public TextBox TextBox { get { return Control as TextBox; } }
    }
}
