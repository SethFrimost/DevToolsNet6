using DevToolsNet.DB.Objects.Configs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Runner.Interfaces
{
    public interface ICommandRuner
    {
        ConnectionString ConnectionString { get; }
        void SetConnection(ConnectionString connectionString);
        string RunNonQuery(string comando);
        List<T> RunQuery<T>(string comando, out string message) where T : new();
        DataSet RunDataset(string comando, out string message);
        DataTable RunDataTable(string comando, out string message);

    }
}
