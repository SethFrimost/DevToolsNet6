using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.TCP.Configs
{
    public class TcpConfig
    {
        public string Key { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }   
        public int BufferSize { get; set; } = 8 * 1024;
    }
}
