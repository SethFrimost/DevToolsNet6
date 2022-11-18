using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.Shared.Configs;

public class GrupoConfig<T>
{
    public string Name { get; set; } = string.Empty;
    public List<GrupoConfig<T>> SubGrupos { get; set; } = new List<GrupoConfig<T>>();
    public List<T> Datos { get; set; } = new List<T>();
    public T Default { get; set; }
}
