using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevToolsNet.WinServicesManager
{
    public class WinServicesManagerConfig
    {
        public enum ServiceAction { Refresh, Play, Stop, Restart }

        public List<WindowsServerServiceConfig> Servers { get; set; }
    }
}
