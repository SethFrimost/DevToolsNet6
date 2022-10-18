using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface IQueryInfoRecover
    {
        List<DevToolsNet.DB.Objects.DataTable> GetQueryInfo(string table);
        List<DevToolsNet.DB.Objects.DataTable> GetQueryInfo(string table, string schema);
        List<DevToolsNet.DB.Objects.DataTable> GetQueryInfoLike(string table);
        List<DevToolsNet.DB.Objects.DataTable> GetQueryInfoLike(string table, string schema);
    }
}
