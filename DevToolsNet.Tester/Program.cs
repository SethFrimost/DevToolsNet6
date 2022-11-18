// See https://aka.ms/new-console-template for more information
using DevToolsNet.DB.Generator;
using Microsoft.Extensions.Configuration;
using DevToolsNet.Generics;
using DevToolsNet.Extensions;
using DevToolsNet.DB.Objects;
using VideoLibrary;
using System.Security;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using System.Reflection;
using DevToolsNet.zzzTester;
using System.Text.Json.Serialization;
using System.Text.Json;

Grupo g = new Grupo() { name = "A", subGrupos= new List<Grupo>() };
g.subGrupos.Add(new Grupo() { name = "A1", padre=g });

JsonSerializerOptions options = new()
{
    ReferenceHandler = ReferenceHandler.Preserve,
    WriteIndented = true
};
var json = System.Text.Json.JsonSerializer.Serialize(g, options);
Console.WriteLine(json);

var g2 = System.Text.Json.JsonSerializer.Deserialize<Grupo>(json, options);

Console.WriteLine("");

/*
Console.WriteLine("Hello, World!");
ConfigurationManager confManager = new ConfigurationManager();
var configs = confManager.AddJsonFile("config.json").Build();
*/

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
//var l = new List<int>() { 4 };


//using VideoLibrary;
/*var VedioUrl = "https://www.youtube.com/embed/lUEXzILh2aQ.mp4";
var youTube = YouTube.Default;
var video = youTube.GetVideo(VedioUrl);
System.IO.File.WriteAllBytes(@"c:\temp\" + video.FullName + ".mp4", video.GetBytes());
*/
/*
try
{
    var sm = new Microsoft.Web.Administration.ServerManager();
    //var sm = Microsoft.Web.Administration.ServerManager.OpenRemote("es-ber1-as1");
 
    // sm.ApplicationPools
    // sm.ApplicationPools[0].sta
    // sm.Sites[0].Applications

    var apps = sm.ApplicationPools.ToList();

    foreach(var app in apps)
    {
        Console.WriteLine(app.Name);
        Console.WriteLine(app.ToString());
    }
}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/
try
{
    string userName = "tuv\\sadm-castell-an";
    string password = "Kiloploki!certi0";
    var securestring = new SecureString();
    foreach (Char c in password)
    {
        securestring.AppendChar(c);
    }
    PSCredential creds = new PSCredential(userName, securestring);
    WSManConnectionInfo connectionInfo = new WSManConnectionInfo();

    connectionInfo.ComputerName = "es-ber1-as1";
    connectionInfo.Credential = creds;

    //String psProg = File.ReadAllText(@"path_for_ps.ps1");
    Runspace runspace = RunspaceFactory.CreateRunspace(connectionInfo);
    runspace.Open();

    /*using (PowerShell ps = PowerShell.Create())
    {
        // specify the script code to run.
        ps.AddScript("ls");

        // specify the parameters to pass into the script.
        //ps.AddParameters("");

        // execute the script and await the result.
        var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

        // print the resulting pipeline objects to the console.
        foreach (var item in pipelineObjects)
        {
            Console.WriteLine(item.BaseObject.ToString());
        }
    }*/

    using (PowerShell ps = PowerShell.Create())
    {
        ps.AddScript("ls c:\\");

        ps.Streams.Error.DataAdded += (s, e) => {
            var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
            var currentStreamRecord = streamObjectsReceived[e.Index];

            Console.WriteLine($"ErrorStreamEvent: {currentStreamRecord.MessageData}");
        };
        ps.Streams.Warning.DataAdded += (s, e) => {
            var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
            var currentStreamRecord = streamObjectsReceived[e.Index];

            Console.WriteLine($"WarningStreamEvent: {currentStreamRecord.MessageData}");
        };
        ps.Streams.Information.DataAdded += (s, e) => {
            var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
            var currentStreamRecord = streamObjectsReceived[e.Index];

            Console.WriteLine($"InfoStreamEvent: {currentStreamRecord.MessageData}");
        };

        Console.WriteLine("----- Pipeline Output below this point -----");
        var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

        // print the resulting pipeline objects to the console.
        foreach (var item in pipelineObjects)
        {
            Console.WriteLine(item.BaseObject.ToString());
        }
    }
    /*
    PowerShell ps = PowerShell.Create(runspace);
    ps.AddScript("ls c:\\");

    ps.Streams.Error.DataAdded += (s,e) => {
        var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
        var currentStreamRecord = streamObjectsReceived[e.Index];

        Console.WriteLine($"ErrorStreamEvent: {currentStreamRecord.MessageData}");
    };
    ps.Streams.Warning.DataAdded += (s, e) => {
        var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
        var currentStreamRecord = streamObjectsReceived[e.Index];

        Console.WriteLine($"WarningStreamEvent: {currentStreamRecord.MessageData}");
    };
    ps.Streams.Information.DataAdded += (s, e) => {
        var streamObjectsReceived = s as PSDataCollection<InformationRecord>;
        var currentStreamRecord = streamObjectsReceived[e.Index];

        Console.WriteLine($"InfoStreamEvent: {currentStreamRecord.MessageData}");
    };

    Console.WriteLine("----- Pipeline Output below this point -----");
    var pipelineObjects = await ps.InvokeAsync().ConfigureAwait(false);

    // print the resulting pipeline objects to the console.
    foreach (var item in pipelineObjects)
    {
        Console.WriteLine(item.BaseObject.ToString());
    }
*/
    runspace.Close();
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


Console.WriteLine("--FIN--");
Console.ReadLine();