using DevToolsNet.AppConfig.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;


namespace DevToolsNet.AppConfig.SQL
{
    public class AppConfigSQLRecover : IConfigRecover
    {
        SqlConnection conn = null;

        public AppConfigSQLRecover(IConfiguration config)
        {
            SetConnectionString(config?.GetConnectionString("AppConfig"));
        }

        private void SetConnectionString(string connString)
        {
            try
            {
                if (connString != null) conn = new SqlConnection(connString);
                else conn = null;
            }
            catch
            {
                conn = null;
            }
        }

        public List<AppConfig> RecoverConfigs(string app, string group, string pc, DateTime date)
        {
            var res = new List<AppConfig>();

            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand(getCommandString(), conn);
                cmd.Parameters.Add("@app", SqlDbType.VarChar).Value = app;
                cmd.Parameters.Add("@group", SqlDbType.VarChar).Value = group ?? String.Empty;
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
                        AppConfig newO = fillAppConfig(r);
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

        public List<AppConfig> RecoverAllConfigs(DateTime date)
        {
            var res = new List<AppConfig>();

            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand(getAllCommandString(), conn);
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
                        AppConfig newO = fillAppConfig(r);
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

        public List<AppConfig> GetAllConfigs(List<AppConfig> configs, string app, string group, string pc, DateTime date)
        {
            List<AppConfig> res = new List<AppConfig>();
            if(configs == null && configs.Count() == 0) return res;

            var confsApp = configs.FindAll(x=>x.App == app && x.From <= date && x.To >=date);

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

        private string getAllCommandString()
        {
            return "select [Id], [App], [Group], [PC], [Name], [Value], [From], [To] from dbo.AppConfig where @date between [From] and [To]";
        }

        public List<AppConfig> RecoverAllConfigs()
        {
            var res = new List<AppConfig>();

            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand(getAllCommandString(), conn);

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
                        AppConfig newO = fillAppConfig(r);
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

        private static AppConfig fillAppConfig(DataRow r)
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
            return newO;
        }



    }
}