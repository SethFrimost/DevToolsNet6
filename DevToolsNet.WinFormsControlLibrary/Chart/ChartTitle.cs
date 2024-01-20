using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WinFormsControlLibrary.Chart
{
    public class ChartTitle
    {
        public string Text { get; set; }
        public Font Font { get; set; }
        public Color ForeColor { get; set; }
        public bool Visible { get; set; }
        internal ChartLocation Location { get; set; } = ChartLocation.Right;
        public Padding Padding { get; set; }

        public ChartTitle() { this.Padding = new Padding(4); }


    }
}
