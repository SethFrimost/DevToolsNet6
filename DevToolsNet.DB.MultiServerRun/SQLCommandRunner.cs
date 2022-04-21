using DevToolsNet.DB.Objects.Configs;
using DevToolsNet.DB.Runner.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevToolsNet.DB.Runner
{
    public class SQLCommandRunner : ICommandRuner, IDisposable
    {
        public ConnectionString connectionString;
        SqlConnection conn;
        private string outMessage = string.Empty;

        public ConnectionString ConnectionString { get { return connectionString; } }

        public void SetConnection(ConnectionString connectionString)
        {
            this.connectionString = connectionString;
            conn = new SqlConnection(connectionString.Value);
        }


        public string RunNonQuery(string comando) 
        {
            outMessage = string.Empty;

            conn.InfoMessage += conn_InfoMessage;
            if(conn.State!= ConnectionState.Open) conn.Open();

            SqlCommand comand = new SqlCommand(comando, conn);
            comand.CommandTimeout = 0;

            StringBuilder sbErr = new StringBuilder();

            var scripts = Regex.Split(comando, @"(\s+|;|\n|\r)(GO|go|Go)", RegexOptions.Multiline);
            foreach (var splitScript in scripts)
            {
                if (!string.IsNullOrWhiteSpace(splitScript) && !Regex.Match(splitScript, @"((\s+|;|\n|\r)(GO|go|Go))|(^(GO|go|Go)$)").Success)
                {
                    try
                    {
                        comand.CommandText = splitScript;
                        comand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        sbErr.Append(ex.Message);
                    }
                }
            }

            //conn.Close();
            //conn.Dispose();

            if (sbErr != null && !string.IsNullOrEmpty(sbErr.ToString()))
            {
                throw new Exception(sbErr.ToString());
            }
            

            return outMessage;
        }

        public List<T> RunQuery<T>(string comando, out string message) where T : new()
        {
            var res = new List<T>();
            var dt = RunDataTable(comando, out message);

            if (dt?.Rows != null)
            {
                var tipoRes = typeof(T);
                foreach (DataRow r in dt.Rows)
                {
                    var newO = new T();
                    foreach (DataColumn c in dt.Columns)
                    {

                        var p = tipoRes.GetProperty(c.ColumnName);
                        if (p != null) p.SetValue(newO, r[c], null);
                    }
                    res.Add(newO);
                }
            }

            return res;
        }

        public DataSet RunDataset(string comando, out string message)
        {
            outMessage = null;
            var ds = new DataSet();
            conn.InfoMessage += conn_InfoMessage;
            if (conn.State != ConnectionState.Open) conn.Open();
            try
            {
                using (SqlCommand comand = new SqlCommand(comando, conn))
                {
                    comand.CommandTimeout = 0;
                    using (SqlDataAdapter da = new SqlDataAdapter(comando, conn))
                    {
                        da.SelectCommand.CommandTimeout = 0;
                        da.Fill(ds);
                    }
                }
            }
            catch (Exception ex)
            {
                message = outMessage;
                throw ex;
            }

            //conn.Close();
            //conn.Dispose();
            message = outMessage;
            return ds;
        }

        public DataTable RunDataTable(string comando, out string message)
        {
            outMessage = null;
            var ds = RunDataset(comando,  out outMessage);
            message = outMessage;

            if (ds?.Tables?.Count > 0) return ds.Tables[0];
            else return null;
        }


        void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (!string.IsNullOrEmpty(outMessage)) outMessage += Environment.NewLine;
            outMessage += e.Message;
        }


        public void Dispose()
        {
            if(conn != null)
            {
                if (conn.State == ConnectionState.Open) conn.Close();
                conn.Dispose();
            }
        }

        
    }
}
