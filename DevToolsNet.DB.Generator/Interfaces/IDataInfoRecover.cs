using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Generator.Interfaces
{
    public interface IDataInfoRecover
    {
        void SetConnection(IDbConnection connection);

        List<DevToolsNet.DB.Objects.DataTable> GetTableInfo(string table);
        List<DevToolsNet.DB.Objects.DataTable> GetTableInfo(string table, string schema);
        List<DevToolsNet.DB.Objects.DataTable> GetTableInfoLike(string table);
        List<DevToolsNet.DB.Objects.DataTable> GetTableInfoLike(string table, string schema);
    }
}
