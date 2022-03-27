using DevToolsNet.DB.Generator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DevToolsNet.DB.Objects.Configs;
using Microsoft.Extensions.Options;

namespace DevToolsNet.DB.Generator
{
    public class LocalXmlTemplateGenerators : IGenerators
    {
        private IConnectionStrings configuration;
        public List<ICodeGenerator> CodeGenerators { get; private set; }

        public LocalXmlTemplateGenerators(IOptions<IConnectionStrings> settings)
        {
            this.configuration = settings.Value;
            LoadGenerators();
        }

        public void LoadGenerators()
        {
            var folder = configuration.XmlsFolder;
            CodeGenerators = new List<ICodeGenerator>();
            try
            {
                if (System.IO.Directory.Exists(folder)) {
                    var files = System.IO.Directory.GetFiles(folder, "*.xml");
                    foreach(var f in files)
                    {
                        CodeGenerators.Add(new GeneratorFromXml(System.IO.File.ReadAllText(f)));
                    }
                }
            }
            catch (Exception ex)
            {
                CodeGenerators = null;
            }
        }

    }
}
