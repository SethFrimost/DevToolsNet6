using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.WinServicesManager
{
    public class WindowsServiceStatus
    {
        public string Key { get; set; }
        public string Server { get; set; }
        public string Name { get; set; }
        public ServiceControllerStatus LastStatus { get; set; }
        public ServiceController ServController { get; set; }
        public Exception? exception { get; set; }
    }
}
