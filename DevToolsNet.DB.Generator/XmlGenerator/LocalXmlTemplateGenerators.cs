using DevToolsNet.DB.Generator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DevToolsNet.DB.Generator
{
    public class LocalXmlTemplateGenerators : IGenerators
    {
        private IConfiguration configuration;
        public List<ICodeGenerator> CodeGenerators { get; private set; }

        public LocalXmlTemplateGenerators(IConfiguration Configuration)
        {
            this.configuration = Configuration;
            LoadGenerators();
        }

        public void LoadGenerators()
        {
            var folder = configuration["LocalXmlTemplateGenerators:XmlsFolder"];
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
