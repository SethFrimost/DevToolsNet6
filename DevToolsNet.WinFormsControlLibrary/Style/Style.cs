using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevToolsNet.WinFormsControlLibrary.Style
{
    public class Style
    {
        public string Name { get; set; }
        [JsonConverter(typeof(ColorHexJsonConverter))] public Color BackgroundColor { get; set; }
        [JsonConverter(typeof(ColorHexJsonConverter))] public Color ForeColor { get; set; }
    }
}
