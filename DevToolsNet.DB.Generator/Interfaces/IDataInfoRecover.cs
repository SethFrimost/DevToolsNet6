using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface IDataInfoRecover
    {
        List<DataTable> GetTableInfo(string table);
        List<DataTable> GetTableInfo(string table, string schema);
        List<DataTable> GetTableInfoLike(string table);
        List<DataTable> GetTableInfoLike(string table, string schema);
    }
}
