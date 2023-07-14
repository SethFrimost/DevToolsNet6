using Markdig.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.PowerShell.ScriptLibrary
{
    public class PSScript
    {
        public string Code {  get; set; }
        public string Name { get; set; }
        public Dictionary<string,string> InheritParams { get; set; }
        public Dictionary<string, string> Params { get; set; }

        public PSScript() 
        {
            Code = Name = string.Empty;
            Params = new Dictionary<string, string>();
            InheritParams = new Dictionary<string, string>();
        }

        public string GetScript()
        {
            var scr = new StringBuilder();

            foreach (var p in InheritParams)
            {
                scr.AppendLine($"${p.Key}={p.Value}");
            }

            foreach (var p in Params)
            {
                scr.AppendLine($"${p.Key}={p.Value}");
            }

            scr.AppendLine(Code);
            return scr.ToString();
        }
    }
}
