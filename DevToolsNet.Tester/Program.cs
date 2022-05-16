// See https://aka.ms/new-console-template for more information
using DevToolsNet.DB.Generator;
using Microsoft.Extensions.Configuration;
using DevToolsNet.Generics;
using DevToolsNet.Extensions;
using DevToolsNet.DB.Objects;

Console.WriteLine("Hello, World!");
ConfigurationManager confManager = new ConfigurationManager();
var configs = confManager.AddJsonFile("config.json").Build();


/*LocalXmlTemplateGenerators generators = new LocalXmlTemplateGenerators(configs);
generators.LoadGenerators();

List<DataTable> datas = new List<DataTable>(); ;
datas.Add(new DataTable()
{
    Tabla = "Centro",
    Schema = "Central",
    Columnas = new List<DataColumn>()
    {
        new DataColumn() { is_identity=true, is_nullable=false, name="id", system_type="bigint"},
        new DataColumn() { is_identity=false, is_nullable=false, name="Codigo", system_type="varchar", max_length=50 },
        new DataColumn() { is_identity=false, is_nullable=false, name="ts", system_type="timestamp", max_length=0 }
    }
});
generators.CodeGenerators.ForEach(g=> Console.WriteLine(g.GenerateCode(datas)));
*/
var l = new List<int>() { 4 };
Console.WriteLine("--FIN--");