// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;

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
using System.Drawing;
using System.Diagnostics;
using System.Configuration;
using DevToolsNet.PowerShell.ScriptLibrary;

PSScript s = new PSScript();
s.Params = new Dictionary<string, string>();
s.Params.Add("dir", "C:\\temp");
s.Name = "data";
s.Code = "asdfasdfasdfa \r\n asdadfasda";

string str = System.Text.Json.JsonSerializer.Serialize(s);

Console.WriteLine(str);
/*
Estilo e = new Estilo() { a = Color.Red, b = Color.FromArgb(100, 200, 50) };
var jsE = System.Text.Json.JsonSerializer.Serialize(e);
var e2 = System.Text.Json.JsonSerializer.Deserialize<Estilo>(jsE);
ColorConverter cc = new ColorConverter();

var c = cc.ConvertFromString("red"); // Color.FromName("ff3355ff");
c = cc.ConvertFromString("#ff3355");
c = cc.ConvertFromString("10;10;10");

Grupo g = new Grupo() { name = "A", subGrupos= new List<Grupo>(), color=Color.Red };
g.subGrupos.Add(new Grupo() { name = "A1", padre=g, color = Color.FromArgb(24,200,240) });

JsonSerializerOptions options = new()
{
ReferenceHandler = ReferenceHandler.Preserve,
WriteIndented = true
};
var json = System.Text.Json.JsonSerializer.Serialize(g, options);
Console.WriteLine(json);

json = "{\r\n  \"$id\": \"1\",\r\n  \"padre\": null,\r\n  \"name\": \"A\",\r\n  \"color\": {\r\n    \"Name\": \"Red\"\r\n  },\r\n  \"subGrupos\": {\r\n    \"$id\": \"2\",\r\n    \"$values\": [\r\n      {\r\n        \"$id\": \"3\",\r\n        \"padre\": {\r\n          \"$ref\": \"1\"\r\n        },\r\n        \"name\": \"A1\",\r\n        \"color\": {\r\n          \"R\": 24,\r\n          \"G\": 200,\r\n          \"B\": 240,\r\n          \"A\": 255\r\n        },\r\n        \"subGrupos\": null\r\n      }\r\n    ]\r\n  }\r\n}";
var g2 = System.Text.Json.JsonSerializer.Deserialize<Grupo>(json, options);

Console.WriteLine("");

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
/*try
{
    Console.WriteLine("set user and pass");
    string userName = Console.ReadLine();
    string password = Console.ReadLine();
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

    using (PowerShell ps = PowerShell.Create())
    {
        //ps.AddCommand()
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
/
    runspace.Close();
    
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}*/


Filtro filtro = new Filtro();
filtro.AddScript("suma", "X + Y");

/*dynamic datos = new System.Dynamic.ExpandoObject();
datos.globals = new System.Dynamic.ExpandoObject();
datos.X = 15;
datos.Y = 5;*/

var p = new Datos();
p.X = 10;
p.Y = 5;
p.matricula = "B-1987-AAA";
p.matricula.StartsWith("B");

filtro.Data = p;
var res4 = filtro.RunScript("suma");

var idPrueba = filtro.Evaluar<int>("if(matricula.StartsWith(\"B\")) return 1; else return 2;", p);

var res = filtro.Evaluar<int>("X + Y", p);
var res2 = filtro.Evaluar<int>("X * Y", p);
var res3 = filtro.Evaluar<string>("if(X > Y) return \"A,B,C\"; else return \"X,C,\";", p);

/*
PowerShell ps = PowerShell.Create();
var c = new Command("$a = 1" + Environment.NewLine
    + "echo $a");
ps.Commands.AddCommand(c);
*/

Console.WriteLine("--FIN--");
Console.ReadLine();