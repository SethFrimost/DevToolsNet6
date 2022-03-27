using DevToolsNet.DB.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Configs
{
    public class LocalXmlTemplateConfigSection : IConnectionStrings
    {
        public string XmlsFolder { get; set; }
        public List<ConectionString> connectionStrings { get; set; }
    }
}
