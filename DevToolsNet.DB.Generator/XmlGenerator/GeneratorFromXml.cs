using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.TemplateObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DevToolsNet.DB.Generator
{
    public class GeneratorFromXml : ICodeGenerator
    {
        private const string tagSchema = "{gSchema}";
        private const string tagTable = "{gTable}";
        private const string tagColName = "{gColName}";
        private const string tagColType = "{gColType}";
        private const string tagColMax = "{gColMax}";
        private const string tagColCType = "{gColC#Type}";
        private const string tagColSqlType = "{gColSqlType}";

        public string Name { get; private set; }

        List<TemplateItem> items = null;

        public GeneratorFromXml(string xml) 
        {
            readXml(xml);
        }

        private void readXml(string xml)
        {
            items = new List<TemplateItem>();
            var doc = XDocument.Parse(xml);
            var root = doc.Root;
            if (root != null)
            {
                Name = root.Attribute("name")?.Value??string.Empty;
                foreach (XElement e in root.Elements())
                {
                    items.Add(new TemplateItem(e));
                }
            }
        }

        public string GenerateCode(List<DataTable> tables)
        {
            if(items != null)
            {
                string code = string.Empty;

                foreach (var t in tables)
                {
                    foreach (var itm in items)
                    {
                        if (itm.ItemType == TemplateItemType.Text) code += TextItem(t, itm.Text);
                        else
                        {
                            var cols = t.Columnas.FindAll(x => (!itm.Identity && !itm.TimeStamp && !itm.NoIdentity && !itm.NoTimeStamp) || 
                                                        (itm.Identity && x.is_identity) || (itm.NoIdentity && !x.is_identity) ||
                                                        (itm.TimeStamp && x.system_type.ToLower() == "timestamp") || (itm.NoTimeStamp && x.system_type.ToLower() != "timestamp")
                                                    );
                            cols.ForEach(c => code += TextItem(t, c, itm.Text));
                        }
                    }
                }
                
                return code;
            }
            else
            {
                return string.Empty;
            }
        }

        private string TextItem(DataTable t, string text)
        {
            return text
                .Replace(tagSchema, t.Schema)
                .Replace(tagTable, t.Tabla);
        }

        private string TextItem(DataTable t, DataColumn c, string text)
        {
            return TextItem(t,text)
                .Replace(tagColName, c.name)
                .Replace(tagColType, c.system_type)
                .Replace(tagColMax, c.max_length.ToString())
                .Replace(tagColCType, getCType(c.system_type))
                .Replace(tagColSqlType, getSqlType(c));
        }

        private string getCType(string system_type)
        {
            var res = system_type;

            switch(system_type.ToLower())
            {
                case "bigint": res = "long"; break;
                case "binary": res = "byte[]"; break;
                case "bit": res = "bool"; break;
                case "char": res = "string"; break;
                case "date": res = "DateTime"; break;
                case "datetime": res = "DateTime"; break;
                case "datetime2": res = "DateTime"; break;
                case "datetimeoffset": res = "DateTimeOffset"; break;
                case "decimal": res = "decimal"; break;
                case "varbinary(max)": res = "byte[]"; break;
                case "float": res = "double"; break;
                case "image": res = "byte[]"; break;
                case "int": res = "int"; break;
                case "money": res = "decimal"; break;
                case "nchar": res = "string"; break;
                case "ntext": res = "string"; break;
                case "numeric": res = "decimal"; break;
                case "nvarchar": res = "string"; break;
                case "real": res = "Single"; break;
                case "rowversion": res = "byte[]"; break;
                case "smalldatetime": res = "DateTime"; break;
                case "smallint": res = "int"; break;
                case "smallmoney": res = "decimal"; break;
                case "text": res = "string"; break;
                case "time": res = "TimeSpan"; break;
                case "timestamp": res = "byte[]"; break;
                case "tinyint": res = "byte"; break;
                case "uniqueidentifier": res = "Guid"; break;
                case "varbinary": res = "byte[]"; break;
                case "varchar": res = "string"; break;
                case "xml": res = "Xml"; break;
            }
            return res;
        }

        private string getSqlType(DataColumn columna)
        {
            if (columna.system_type.Contains("char"))
                return string.Format("{0}({1})", columna.system_type, columna.max_length == -1 ? "MAX" : columna.max_length.ToString());
            return columna.system_type == "decimal" ? string.Format("{0}({1},{2})", columna.system_type, columna.max_length, columna.scale) : columna.system_type;
        }
    }
}
