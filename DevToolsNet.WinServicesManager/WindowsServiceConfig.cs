using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevToolsNet.WinServicesManager
{
    public class WindowsServiceConfig : Shared.Configs.ServerConfig
    {
        public List<string> Servicios { get; set; } = new List<string>();
    }
}
