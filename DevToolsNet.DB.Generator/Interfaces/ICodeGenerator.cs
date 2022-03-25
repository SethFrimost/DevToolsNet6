using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface ICodeGenerator
    {
        string Name { get; }
        string GenerateCode(List<DataTable> tables);
    }
}
