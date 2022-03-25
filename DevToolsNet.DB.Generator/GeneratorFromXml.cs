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
        private const string tagColCType = "{gColC#Type}";

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
                        if (itm.ItemType == TemplateItemType.Text)
                        {
                            
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
                .Replace(tagColCType, getCType(c.system_type));
        }

        private string getCType(string system_type)
        {
            var res = "--";

            switch(system_type.ToLower())
            {
                case "bigint": res = "Int64"; break;
                case "binary": res = "Byte[]"; break;
                case "bit": res = "Boolean"; break;
                case "char": res = "String"; break;
                case "date 1": res = "DateTime"; break;
                case "datetime": res = "DateTime"; break;
                case "datetime2": res = "DateTime"; break;
                case "datetimeoffset": res = "DateTimeOffset"; break;
                case "decimal": res = "Decimal"; break;
                case "varbinary(max)": res = "Byte[]"; break;
                case "float": res = "Double"; break;
                case "image": res = "Byte[]"; break;
                case "int": res = "Int32"; break;
                case "money": res = "Decimal"; break;
                case "nchar": res = "String"; break;
                case "ntext": res = "String"; break;
                case "numeric": res = "Decimal"; break;
                case "nvarchar": res = "String"; break;
                case "real": res = "Single"; break;
                case "rowversion": res = "Byte[]"; break;
                case "smalldatetime": res = "DateTime"; break;
                case "smallint": res = "Int16"; break;
                case "smallmoney": res = "Decimal"; break;
                case "sql_variant": res = "Object 2"; break;
                case "text": res = "String"; break;
                case "time": res = "TimeSpan"; break;
                case "timestamp": res = "Byte[]"; break;
                case "tinyint": res = "Byte"; break;
                case "uniqueidentifier": res = "Guid"; break;
                case "varbinary": res = "Byte[]"; break;
                case "varchar": res = "String"; break;
                case "xml": res = "Xml"; break;

            }
            return res;
        }
    }
}
