using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface IGenerators
    {
        List<ICodeGenerator> CodeGenerators { get; }
        void LoadGenerators();

    }
}
