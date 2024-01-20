using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WinFormsControlLibrary.Chart
{
    public class ChartLegend
    {
        internal ChartSerie series { get; set; } 
        public Font Font { get; set; }
        public Color ForeColor { get; set; }
        public bool Visible { get; set; }
        internal ChartLocation Location { get; set; } = ChartLocation.Top;
        public Padding Padding { get; set; } = new Padding(3);
    }
}
