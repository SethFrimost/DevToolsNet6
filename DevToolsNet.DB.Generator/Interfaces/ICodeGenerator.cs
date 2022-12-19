using DevToolsNet.DB.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface ICodeGenerator
    {
        Dictionary<string, string> Items { get; }
        Dictionary<string, string> ItemsOptions { get; }
        Dictionary<string, string> DataTags { get; }
        string Name { get; set; }
        void LoadXML(string xml);
        string GenerateCode(DataTable tables);
        string GenerateCode(List<DataTable> tables);
        List<TableCode> GenerateCodeList(List<DataTable> tables);

    }
}
