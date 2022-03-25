// See https://aka.ms/new-console-template for more information
using DevToolsNet.DB.Generator;
using Microsoft.Extensions.Configuration;


Console.WriteLine("Hello, World!");
ConfigurationManager confManager = new ConfigurationManager();
var configs = confManager.AddJsonFile("config.json").Build();

LocalXmlTemplateGenerators generators = new LocalXmlTemplateGenerators(configs);
generators.LoadGenerators();