using DevToolsNet.DB.Objects.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Interfaces
{
    public interface IConnectionStrings
    {
        List<ConnectionString> connectionStrings { get; set; }
    }
}
