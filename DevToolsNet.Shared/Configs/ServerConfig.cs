using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Shared.Configs
{ 

public class ServersConfig<T> // where T : ServerConfig
{
    public List<GrupoConfig<T>> Servers { get; set; }
}

public class ServerConfig
{
    public string Name { get; set; }
    public string IP { get; set; }
}

}