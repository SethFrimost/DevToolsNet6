using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevToolsNet.zzzTester
{
    internal class Grupo
    {
        public Grupo padre { get; set; } = null;
        public string name { get; set; } = null;
        public List<Grupo> subGrupos { get; set; } = null;
    }
}
