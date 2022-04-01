using DevToolsNet.AppConfig.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace DevToolsNet.AppConfig.SQL
{
    public class AppConfigSQLRecover: IConfigRecover
    {
        SqlConnection conn;
        
        public void SetConnectionString(string connString)
        {
            conn = new SqlConnection(connString);
        }

        public List<AppConfig> RecoverConfigs(string app, string pc, DateTime date)
        {
            var res = new List<AppConfig>();
            
            SqlCommand cmd = new SqlCommand(getCommandString(), conn);
            cmd.Parameters.Add("@app",SqlDbType.UniqueIdentifier).Value = app;
            cmd.Parameters.Add("@pc", SqlDbType.VarChar).Value = pc;
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;

            if (conn.State != ConnectionState.Open) conn.Open();
            try
            {
                var ds = new DataSet();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(ds);
                }

                var tipoRes = typeof(AppConfig);
                foreach (DataRow r in ds.Tables[0].Rows)
                {
                    var newO = new AppConfig();
                    foreach (DataColumn c in ds.Tables[0].Columns)
                    {
                        var p = tipoRes.GetProperty(c.ColumnName);
                        if (p != null) p.SetValue(newO, r[c], null);
                    }
                    res.Add(newO);
                }
            }
            catch
            {
                throw;
            }

            return res;
        }

        private string getCommandString()
        {
            return "select Id, App, PC, Name, Value, From, To " +
                "from dbo.AppConfig " +
                "where App=@app and pc=@pc and @date between From and To";
        }

    }
}