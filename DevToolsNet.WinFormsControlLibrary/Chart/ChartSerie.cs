using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WinFormsControlLibrary.Chart
{
    public class ChartSerie
    {
        public string Name { get; set; }
        public IList<float> Values { get; set; }
        public Color Color { get; set; }
        public int Order { get; set; }
        public object Tag { get; set; }
        public Padding Padding { get; set; }
    }
}
