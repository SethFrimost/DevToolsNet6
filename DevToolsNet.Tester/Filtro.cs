using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Management.Automation.Language;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Drawing;

namespace DevToolsNet.zzzTester
{
    internal class Filtro
    {
        public object Data { get; set; }

        Dictionary<string, Script> scritps;
       
        public Filtro()
        {
            scritps = new Dictionary<string, Script>();
        }

        
        public bool evaluarMatricula(dynamic datos)
        {
            return string.IsNullOrEmpty(datos.Matricula);
        }

        public Script AddScript(string key, string code)
        {
            var s =  CSharpScript.Create(code);
            scritps.Add(key, s);
            return s;
        }

        public object RunScript(string key)
        {
            return RunScript(key,Data);
        }

        public object RunScript(string key, object datos)
        {
            if(scritps.TryGetValue(key, out var script))
            {
                return script.RunAsync(globals: datos).Result;
            }
            return null;
        }

        public T Evaluar<T>(string code, object datos)
        {
            return CSharpScript.EvaluateAsync<T>(code, globals:datos).Result;
        }
    }

    public class Datos
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

}
