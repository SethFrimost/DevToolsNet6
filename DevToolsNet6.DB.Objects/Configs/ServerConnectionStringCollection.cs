using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Configs
{
    public class ServerConnectionStringCollection : Shared.Configs.ServerConfig
    {
        public List<ConnectionString> Connections { get; set; }

        public List<ConnectionString> GetByName(string name)
        {
            return Connections.FindAll(x=>x.Name==name);
        }
    }
}
