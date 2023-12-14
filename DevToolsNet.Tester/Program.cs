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
using Microsoft.CodeAnalysis.Scripting;

PSScript s = new PSScript();
s.Params = new Dictionary<string, string>();
s.Params.Add("dir", "C:\\temp");
s.Name = "data";
s.Code = "asdfasdfasdfa \r\n asdadfasda";

string str = System.Text.Json.JsonSerializer.Serialize(s);

Console.WriteLine(str);


Filtro filtro = new Filtro();
filtro.AddScript("suma", "data.X + data.Y");
/*
dynamic datos = new System.Dynamic.ExpandoObject();
datos.globals = new System.Dynamic.ExpandoObject();
datos.X = 15;
datos.Y = 5;
var a = filtro.RunScript("suma", datos);

Dictionary<string,object> dict = new Dictionary<string,object>();
dict.Add("X", 15);
dict.Add("Y", 5);
*/
var p = new Datos();
p.X = 10;
p.Y = 5;
p.matricula = "B-1987-AAA";
p.matricula.StartsWith("B");


//var res4 = filtro.RunScript("suma", datos);

filtro.Data = p;
//var res4 = filtro.RunScript("suma", p);

var idPrueba = filtro.Evaluar<int>("if(matricula.StartsWith(\"B\")) return 1; else return 2;", p);

var res = filtro.Evaluar<int>("X + Y", p);
var res2 = filtro.Evaluar<int>("X * Y", p);
var res3 = filtro.Evaluar<string>("if(X > Y) return \"A,B,C\"; else return \"X,C,\";", p);


Console.WriteLine("--FIN--");
Console.ReadLine();