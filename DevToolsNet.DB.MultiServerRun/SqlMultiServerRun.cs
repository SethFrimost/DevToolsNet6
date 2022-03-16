using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevToolsNet.DB.SqlMultiServerRun
{
    public class SqlMultiServerRun
    {
        private string outMessage = string.Empty;

        public string EjecutarNonQuery(string comando, string conString)
        {
            outMessage = string.Empty;
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.InfoMessage += conn_InfoMessage;
                conn.Open();

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

                conn.Close();
                conn.Dispose();

                if (sbErr != null && !string.IsNullOrEmpty(sbErr.ToString()))
                {
                    throw new Exception(sbErr.ToString());
                }
            }

            return outMessage;
        }

        public List<T> EjecutarQuery<T>(string comando, string conString, out string message) where T : new()
        {
            var res = new List<T>();
            var dt = EjecutarDataTable(comando, conString, out message);

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

        public DataSet EjecutarDataset(string comando, string conString, out string message)
        {
            outMessage = null;
            var ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(conString))
            {
                conn.InfoMessage += conn_InfoMessage;
                conn.Open();

                try
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(comando, conn))
                    {
                        da.Fill(ds);
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    message = outMessage;
                    throw ex;
                }

                conn.Close();
                conn.Dispose();
            }
            message = outMessage;
            return ds;
        }

        public DataTable EjecutarDataTable(string comando, string conString, out string message)
        {
            outMessage = null;
            var ds = EjecutarDataset(comando, conString, out outMessage);
            message = outMessage;

            if (ds?.Tables?.Count > 0) return ds.Tables[0];
            else return null;
        }

        void conn_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            if (!string.IsNullOrEmpty(outMessage)) outMessage += Environment.NewLine;
            outMessage += e.Message;
        }


    }
}
