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
            try
            {
                conn = new SqlConnection(connString);
            }
            catch {
                conn = null;
            }
        }

        public List<AppConfig> RecoverConfigs(string app, string? group, string? pc, DateTime date)
        {
            var res = new List<AppConfig>();
            
            if(conn != null) { 
                SqlCommand cmd = new SqlCommand(getCommandString(), conn);
                cmd.Parameters.Add("@app",SqlDbType.VarChar).Value = app;
                cmd.Parameters.Add("@group", SqlDbType.VarChar).Value = group??String.Empty;
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
                        newO.Id = (Guid)r["Id"];
                        newO.App = r["App"].ToString();
                        newO.Group = r["Group"]?.ToString();
                        newO.PC = r["Pc"]?.ToString();
                        newO.Name = r["Name"].ToString();
                        newO.Value = r["Value"].ToString();
                        newO.From = (DateTime)r["From"];
                        newO.To = (DateTime)r["To"];
                    
                        res.Add(newO);
                    }
                }
                catch
                {
                    throw;
                }
            }

            return res;
        }

        private string getCommandString()
        {
            return "select [Id], [App], [Group], [PC], [Name], [Value], [From], [To] " +
                "from dbo.AppConfig " +
                "where App=@app" +
                " and isnull([Group],isnull(@group,'')) = isnull(@group,'') " +
                " and isnull(pc,isnull(@pc,'')) = isnull(@pc,'') " +
                " and @date between [From] and [To]";
        }
    }
}