using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.PowerShell.ScriptLibrary
{
    public class PSGallery
    {
        public string Name { get; set; }
        public List<PSScript> Scripts { get; set; }
        public Dictionary<string, string> GlobalParams { get; set; }

        public PSGallery() 
        {
            Name = string.Empty;
            Scripts = new List<PSScript>();
            GlobalParams = new Dictionary<string, string>();
        }

        public PSGallery(string directory) { LoadFromDirectory(directory); }

        public void LoadFromDirectory(string directory) 
        {
            directory = Path.TrimEndingDirectorySeparator(directory);
            Scripts = new List<PSScript>();
            Name = Path.GetFileName(directory);
            GlobalParams = new Dictionary<string, string>();

            foreach (string f in Directory.GetFiles(directory,"*.json"))
            {
                if (Path.GetFileName(f) == ".json") GlobalParams = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(f));
                else Scripts.Add(System.Text.Json.JsonSerializer.Deserialize<PSScript>(File.ReadAllText(f)));
            }
        }

        public void SaveToDirectory(string basePath)
        {
            var dir = System.IO.Directory.CreateDirectory(Path.Combine(basePath,Name));
            var f = Path.Combine(dir.FullName, ".json");
            System.IO.File.WriteAllText(f, System.Text.Json.JsonSerializer.Serialize(GlobalParams));

            foreach (var s in Scripts) 
            {
                var n = s.Name;
                Path.GetInvalidFileNameChars().ToList().ForEach(c => n = n.Replace(c,'\0'));
                f = Path.Combine(dir.FullName, n) + ".json";
               
                System.IO.File.WriteAllText(f, System.Text.Json.JsonSerializer.Serialize(s));
            }
        }

        public void RemoveFromDirectory(string basePath)
        {
            System.IO.Directory.Delete(Path.Combine(basePath, Name), true);
        }
        public void RemoveScript(string basePath, PSScript s)
        {
            Scripts.Remove(s);
            var f = Path.Combine(Path.Combine(basePath, Name), s.Name+".json");
            System.IO.File.Delete(f);
        }


        public string GetScriptCode(PSScript s)
        {
            s.InheritParams = GlobalParams;
            return s.GetScript();
        }
        
    }
}
