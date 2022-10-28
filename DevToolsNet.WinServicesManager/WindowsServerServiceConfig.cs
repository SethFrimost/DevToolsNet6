using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevToolsNet.WinServicesManager
{
    public class WindowsServerServiceConfig
    {
        public WindowsServerServiceConfig()
        {
            Servicios = new List<string>();
        }

        public string Name { get; set; }
        public string IP { get; set; }
        public List<string> Servicios { get; set; }
    }
}
