using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Objects.Configs
{
    public class LocalXmlTemplateConfigSection 
    {
        public string FolderPath { get; set; }
        public List<ConectionString> connectionStrings { get; set; }
    }
}
