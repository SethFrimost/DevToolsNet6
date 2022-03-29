using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace DevToolsNet.DB.Generator
{
    public class SqlDataInfoRecover : ITableDataInfoRecover
    {
        public IDbConnection connection {get;set;}


        public void SetConnection(IDbConnection connection)
        {
            this.connection = connection;
        }

        public List<DevToolsNet.DB.Objects.DataTable> GetTableInfo(string table)
        {
            return getTableInfo(table, string.Empty, false);
        }

        public List<DevToolsNet.DB.Objects.DataTable> GetTableInfo(string table, string schema)
        {
            return getTableInfo(table, schema, false);
        }

        public List<DevToolsNet.DB.Objects.DataTable> GetTableInfoLike(string table)
        {
            return getTableInfo(table, string.Empty, true);
        }

        public List<DevToolsNet.DB.Objects.DataTable> GetTableInfoLike(string table, string schema)
        {
            return getTableInfo(table, schema, true);
        }


        private List<DevToolsNet.DB.Objects.DataTable> getTableInfo(string table, string schema, bool useLike)
        {
            var sql = getSqlDataTable(table, schema, useLike);

            SqlConnection con = new SqlConnection(connection.ConnectionString);
            SqlCommand com = new SqlCommand(sql, con);

            if (con.State == ConnectionState.Closed) con.Open();
            SqlDataReader sqlDataReader = com.ExecuteReader();

            if (sqlDataReader != null)
            {
                List<PlainDataTable> source = new List<PlainDataTable>();
                while (sqlDataReader.Read())
                {
                    source.Add(new PlainDataTable()
                    {
                        DataBase = connection.Database,
                        Schema = sqlDataReader[0].ToString(),
                        Tabla = sqlDataReader[1].ToString(),
                        Columna = sqlDataReader[2].ToString(),
                        system_type_id = (int)(byte)sqlDataReader[3],
                        system_type = sqlDataReader[4].ToString(),
                        max_length = (int)(short)sqlDataReader[5],
                        precision = (int)(byte)sqlDataReader[6],
                        scale = (int)(byte)sqlDataReader[7],
                        is_nullable = (bool)sqlDataReader[8],
                        is_identity = (bool)sqlDataReader[9]
                    });
                }
                con.Close();
                return source.GroupBy(t => new { db=t.DataBase, schema = t.Schema, table = t.Tabla })
                    .Select(d => new DevToolsNet.DB.Objects.DataTable()
                    {
                        DataBase= d.Key.db,
                        Tabla = d.Key.table,
                        Schema = d.Key.schema,
                        Columnas = d.Select(c => new DevToolsNet.DB.Objects.DataColumn()
                        {
                            name = c.Columna,
                            system_type_id = c.system_type_id,
                            system_type = c.system_type,
                            max_length = c.max_length,
                            precision = c.precision,
                            scale = c.scale,
                            is_nullable = c.is_nullable,
                            is_identity = c.is_identity
                        }).ToList()
                    }).ToList();
;
            }
            else
            { 
                con.Close();
                return null;
            }
        }

        private static string getSqlDataTable(string schema, string tabla, bool useLike)
        {
            string str = string.Empty + "SELECT s.name [schema], o.name tabla, c.name columna, c.system_type_id, t.name dataType, c.max_length, c.precision, c.scale, c.is_nullable, c.is_identity " + "from sys.objects o " + "\tINNER JOIN sys.schemas s ON o.schema_id = s.schema_id" + "\tinner join sys.columns c ON c.object_id = o.object_id" + "\tinner join sys.types   t ON t.system_type_id = c.system_type_id" + " where o.type = 'U' and o.name <> 'sysdiagrams'";
            if (useLike)
            {
                if (!string.IsNullOrWhiteSpace(schema))
                    str += string.Format(" AND o.name like '{0}'", (object)schema.Trim());
                if (!string.IsNullOrWhiteSpace(tabla))
                    str += string.Format(" AND o.name like '{0}'", (object)tabla.Trim());
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(schema))
                    str += string.Format(" AND s.name = '{0}'", (object)schema.Trim());
                if (!string.IsNullOrWhiteSpace(tabla))
                    str += string.Format(" AND o.name = '{0}'", (object)tabla.Trim());
            }
            return str + " order by o.name, c.column_id;";
        }


        
    }
}
