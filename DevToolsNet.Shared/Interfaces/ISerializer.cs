using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Shared.Interfaces
{
    public interface ISerializer
    {
        string Serialize<T>(T o);
        T Deserialize<T>(string data);
    }
}
