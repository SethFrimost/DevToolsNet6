using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WinServicesManager
{
    public class WindowsServiceConfig
    {
        public List<WindowsServiceDataConfig> WindowsServiceDataConfigs { get; set; } = new List<WindowsServiceDataConfig>();
    }

    public class WindowsServiceDataConfig
    {
        public string Name { get; set; }
        public string Server { get; set; }
    }
}
