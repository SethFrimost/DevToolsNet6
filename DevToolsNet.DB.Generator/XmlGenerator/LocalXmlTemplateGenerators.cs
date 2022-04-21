using DevToolsNet.DB.Generator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using DevToolsNet.DB.Objects.Configs;
using Microsoft.Extensions.Options;
using DevToolsNet.DB.Objects.Interfaces;

namespace DevToolsNet.DB.Generator
{
    public class LocalXmlTemplateGenerators : IGenerators
    {
        private LocalXmlTemplateConfigSection configuration;
        public List<ICodeGenerator> CodeGenerators { get; private set; }

        public LocalXmlTemplateGenerators(IOptions<LocalXmlTemplateConfigSection> settings)
        {
            this.configuration = settings?.Value??new LocalXmlTemplateConfigSection();
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
