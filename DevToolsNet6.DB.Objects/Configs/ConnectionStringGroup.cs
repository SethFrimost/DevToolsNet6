using DevToolsNet.DB.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Configs
{
    public class ConnectionStringGroup : IConnectionStrings
    {
        public string group { get; set; }
        public List<ConectionString> connectionStrings { get; set; }

        public List<ConnectionStringGroup> Groups { get; set; }

    }
}
