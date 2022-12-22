using DevToolsNet.DB.Generator.Interfaces;
using DevToolsNet.DB.Objects;
using DevToolsNet.DB.Objects.TemplateObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using DataColumn = DevToolsNet.DB.Objects.DataColumn;
using DataTable = DevToolsNet.DB.Objects.DataTable;

namespace DevToolsNet.DB.Generator
{
    public class GeneratorFromXml : ICodeGenerator
    {
        private const string tagDatabase = "{gDB}";
        private const string tagSchema = "{gSchema}";
        private const string tagTable = "{gTable}";
        private const string tagColName = "{gColName}";
        private const string tagColType = "{gColType}";
        private const string tagColMax = "{gColMax}";
        private const string tagColCType = "{gColC#Type}";
        private const string tagColSqlType = "{gColSqlType}";

        private const string tagIndexName = "{gIndxName}";

        public string Name { get; set; }

        public Dictionary<string, string> Items { get; private set; }
        public Dictionary<string, string> ItemsOptions { get; private set; }
        public Dictionary<string, string> DataTags { get; private set; }

        List<TemplateItem>? items = null;

        public GeneratorFromXml() 
        {
            fillDictionaries();
        }

        public GeneratorFromXml(string xml) : this()
        {
            readXml(xml);
        }

        void fillDictionaries()
        {
            Items = new Dictionary<string, string>();
            ItemsOptions = new Dictionary<string, string>();
            DataTags = new Dictionary<string, string>();

            Items.Add("Text", "<t></t>");
            Items.Add("Columns", "<c></c>");
            Items.Add("Indexes", "<i></i>");
            Items.Add("Index Columns", "<ic></ic>");

            ItemsOptions.Add("Atributo trim", "trim=\"\"");
            ItemsOptions.Add("Atributo opciones", "opts=\"\"");
            ItemsOptions.Add("Primary Key", "pk");
            ItemsOptions.Add("No Primary Key","nopk");
            ItemsOptions.Add("Identity column", "identity");
            ItemsOptions.Add("No Identity column","noidentity");
            ItemsOptions.Add("Timestamp", "timestamp");
            ItemsOptions.Add("No timestamp", "notimestamp");
            ItemsOptions.Add("Indice único", "indexuk");
            ItemsOptions.Add("Indice habilitado","indexenabled");

            DataTags.Add("Base de datos",tagDatabase);
            DataTags.Add("Schema",tagSchema);
            DataTags.Add("Tabla",tagTable);
            DataTags.Add("Columna Nombre",tagColName);
            DataTags.Add("Columna Tipo", tagColType);
            DataTags.Add("Columna Max", tagColMax);
            DataTags.Add("Columna Tipo C#", tagColCType);
            DataTags.Add("Columna Tipo SQL", tagColSqlType);
            DataTags.Add("Indice", tagIndexName);
    }


        #region Load XML

        public void LoadXML(string xml)
        {
            readXml(xml);
        }

        private void readXml(string xml)
        {
            items = new List<TemplateItem>();
            var doc = XDocument.Parse(xml, LoadOptions.PreserveWhitespace);
            var root = doc.Root;
            if (root != null)
            {
                Name = root.Attribute("name")?.Value ?? string.Empty;
                foreach (XNode n in root.Nodes())
                {
                    if (n.NodeType == XmlNodeType.Text) items.Add(createItem((XText)n));// new TemplateItem(((XText)n)));
                    else items.Add(createItem((XElement)n));
                    
                    //items.Add(createItem(e));
                }
            }
        }

        private TemplateItem createItem(XElement e)
        {
            var ti = new TemplateItem();
            loadItem(ti, e);
            return ti;
        }
        private TemplateItem createItem(XText e)
        {
            var ti = new TemplateItem();
            loadItem(ti, e);
            return ti;
        }


        private void loadItem(TemplateItem itm, XElement xmlElement)
        {
            if (xmlElement.Name.LocalName.ToLower() == "columns" || xmlElement.Name.LocalName.ToLower() == "c") itm.ItemType = TemplateItemType.Columns;
            else if (xmlElement.Name.LocalName.ToLower() == "indexcolumns" || xmlElement.Name.LocalName.ToLower() == "ic") itm.ItemType = TemplateItemType.IndexColumns;
            else if (xmlElement.Name.LocalName.ToLower() == "index" || xmlElement.Name.LocalName.ToLower() == "i") itm.ItemType = TemplateItemType.Index;
            else itm.ItemType = TemplateItemType.Text;

            itemOptions(itm, xmlElement);

            var trim = xmlElement.Attributes("trim").FirstOrDefault();
            if (trim != null) itm.TrimText = trim.Value;
            else itm.TrimText = string.Empty;

            if (xmlElement.HasElements)
            {
                itm.Childrens = new List<TemplateItem>();
                foreach (XNode n in xmlElement.Nodes())
                {
                    if (n.NodeType == XmlNodeType.Text) itm.Childrens.Add(createItem((XText)n));// new TemplateItem(((XText)n)));
                    else
                    {
                        var ti = createItem((XElement)n);
                        ti.Parent = itm;
                        itm.Childrens.Add(ti);
                    }
                }
            }

            itm.Text = xmlElement.Value ?? String.Empty;
        }

        private void loadItem(TemplateItem itm, XText xmlText)
        {
            itm.ItemType = TemplateItemType.Text;
            itm.Text = xmlText.Value ?? String.Empty;
        }

        private void itemOptions(TemplateItem itm, XElement xmlElement)
        {
            var opt = xmlElement.Attributes("opts").FirstOrDefault();

            itm.PK = false;
            itm.NoPK = false;
            itm.Identity = false;
            itm.NoIdentity = false;
            itm.TimeStamp = false;
            itm.NoTimeStamp = false;
            itm.IndexUK = false;
            itm.IndexEnabled = false;

            if (opt != null)
            {
                var opts = opt.Value.Split(' ');

                foreach (var o in opts)
                {
                    switch (o.ToLower())
                    {
                        case "pk": itm.PK = true; break;
                        case "nopk": itm.NoPK = true; break;
                        case "identity": itm.Identity = true; break;
                        case "noidentity": itm.NoIdentity = true; break;
                        case "timestamp": itm.TimeStamp = true; break;
                        case "notimestamp": itm.NoTimeStamp = true; break;
                        case "indexuk": itm.IndexUK = true; break;
                        case "indexenabled": itm.IndexEnabled = true; break;
                    }
                }
            }
        }

        #endregion



        #region Code generator

        public List<TableCode> GenerateCodeList(List<DataTable> tables)
        {
            var res = new List<TableCode>();

            if (items != null)
            {
                string code = string.Empty;

                foreach (var t in tables)
                {
                    code = String.Empty;
                    res.Add(new TableCode() 
                    { 
                        Table = t.Tabla, 
                        Code = GenerateCode(t) 
                    });
                }
            }

            return res;
        }

        public string GenerateCode(List<DataTable> tables)
        {
            if(items != null)
            {
                string code = string.Empty;

                foreach (var t in tables)
                {
                    code += GenerateCode(t);
                }
                
                return code;
            }
            else
            {
                return string.Empty;
            }
        }

        public string GenerateCode(DataTable t)
        {
            return CodeItems(items, t, null, null);
        }


        private string CodeItems(List<TemplateItem> items, DataTable t, DataIndex idx = null, DataColumn col=null)
        {
            string code = string.Empty;

            foreach (var itm in items)
            {
                if(itm.ItemType == TemplateItemType.Columns)
                {
                    var cols = GetColumns(t, itm);
                    cols.ForEach(c =>
                    {
                        if (itm.Childrens.Count > 0) code += CodeItems(itm.Childrens, t, idx, c);
                        else code += TextItem(itm.Text, t, c, idx); //TextItem(itm.Text,t, c, idx);
                    });
                }
                else if(itm.ItemType == TemplateItemType.Index)
                {
                    var indx = GetIndices(t, itm);
                    indx.ForEach(i =>
                    {
                        if (itm.Childrens.Count > 0) code += CodeItems(itm.Childrens, t, i, col);
                        else code += TextItem(itm.Text, t, col, idx); //TextItem(t, i, itm.Text);
                    });
                }
                else if(itm.ItemType == TemplateItemType.IndexColumns)
                    idx.Columnas.ForEach(ic => code += TextItem(itm.Text, t, ic, idx)); //TextItem(t, ic, itm.Text));
                else
                    if (itm.Childrens.Count > 0) code += CodeItems(itm.Childrens, t, idx, col);
                    else code += TextItem(itm.Text, t, col, idx); //TextItem(itm.Text,t, c, idx);

                //code += TextItem(itm.Text, t, col, idx); //TextItem(t, itm.Text);

                if (!string.IsNullOrEmpty(itm.TrimText)) code = code.TrimEnd(itm.TrimText.ToCharArray());
            }

            return code;
        }


        private List<DataColumn> GetColumns(DataTable t, TemplateItem itm)
        {
            return t.Columnas.FindAll(x => (!itm.PK && !itm.NoPK && !itm.Identity && !itm.TimeStamp && !itm.NoIdentity && !itm.NoTimeStamp) ||
                            (
                            ((!itm.PK && !itm.NoPK) || (itm.PK && x.is_primary_key) || (itm.NoPK && !x.is_primary_key)) &&
                            ((!itm.Identity && !itm.NoIdentity) || (itm.Identity && x.is_identity) || (itm.NoIdentity && !x.is_identity)) &&
                            ((!itm.TimeStamp && !itm.NoTimeStamp) || (itm.TimeStamp && x.system_type.ToLower() == "timestamp") || (itm.NoTimeStamp && x.system_type.ToLower() != "timestamp"))
                            )
                        );
        }

        private List<DataIndex> GetIndices(DataTable t, TemplateItem itm)
        {
            return t.Indexes.FindAll(x => !itm.IndexUK || (itm.IndexUK && x.is_unique));
        }

        private string TextItem(string text, DataTable t, DataColumn c = null, DataIndex i = null)
        {
            var res = TextItem(t, text);
            if(c != null) res = TextItem(t, c, res);
            if(i != null) res = TextItem(t, i, res);
            return res;
        }

        private string TextItem(DataTable t, string text)
        {
            return text
                .Replace(tagDatabase, t.DataBase)
                .Replace(tagSchema, t.Schema)
                .Replace(tagTable, t.Tabla);
        }

        private string TextItem(DataTable t, DataColumn c, string text)
        {
            return TextItem(t,text)
                .Replace(tagColName, c.name)
                .Replace(tagColType, c.system_type)
                .Replace(tagColMax, c.max_length.ToString())
                .Replace(tagColCType, getCType(c.system_type, c.is_nullable))
                .Replace(tagColSqlType, getSqlType(c));
        }

        private string TextItem(DataTable t, DataIndex i, string text)
        {
            return TextItem(t, text)
                .Replace(tagIndexName, i.name);
        }


        private string getCType(string system_type, bool nullable)
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
            if (nullable) res += "?";
            return res;
        }

        private string getSqlType(DataColumn columna)
        {
            if (columna.system_type.Contains("char"))
                return string.Format("{0}({1})", columna.system_type, columna.max_length == -1 ? "MAX" : columna.max_length.ToString());
            return columna.system_type == "decimal" ? string.Format("{0}({1},{2})", columna.system_type, columna.max_length, columna.scale) : columna.system_type;
        }


        #endregion


        /*
        private string CodeTable(string code, DataTable t)
        {
            foreach (var itm in items)
            {
                if (itm.ItemType == TemplateItemType.Text) code += TextItem(t, itm.Text);
                else if (itm.ItemType == TemplateItemType.Index)
                {
                    var indx = GetIndices(t,itm);
                    indx.ForEach(i =>
                    {
                        code += CodeIndex(t, i, itm);
                    });
                    if(!string.IsNullOrEmpty(itm.TrimText)) code = code.TrimEnd(itm.TrimText.ToCharArray());
                }
                else
                {
                    var cols = t.Columnas.FindAll(x => (!itm.PK && !itm.NoPK && !itm.Identity && !itm.TimeStamp && !itm.NoIdentity && !itm.NoTimeStamp) ||
                                                (
                                                ((!itm.PK && !itm.NoPK) || (itm.PK && x.is_primary_key) || (itm.NoPK && !x.is_primary_key)) &&
                                                ((!itm.Identity && !itm.NoIdentity) || (itm.Identity && x.is_identity) || (itm.NoIdentity && !x.is_identity)) &&
                                                ((!itm.TimeStamp && !itm.NoTimeStamp) || (itm.TimeStamp && x.system_type.ToLower() == "timestamp") || (itm.NoTimeStamp && x.system_type.ToLower() != "timestamp"))
                                                )
                                            );
                    cols.ForEach(c => code += TextItem(t, c, itm.Text));
                }
                if (!string.IsNullOrEmpty(itm.TrimText)) code = code.TrimEnd(itm.TrimText.ToCharArray());
            }

            return code;
        }

        private string CodeIndex(DataTable t, DataIndex i, TemplateItem itm)
        {
            string code = string.Empty;
            if(itm.Childrens.Count > 0)
            {
                foreach (var cItm in itm.Childrens)
                {
                    if (cItm.ItemType == TemplateItemType.Text) code += TextItem(t, cItm.Text);
                    else if (cItm.ItemType == TemplateItemType.IndexColumns)
                    {
                        i.Columnas.ForEach(c => code += TextItem(t, c, cItm.Text));
                    }

                    if (!string.IsNullOrEmpty(itm.TrimText)) code = code.TrimEnd(cItm.TrimText.ToCharArray());
                }
            }
            else
            {
                code += TextItem(t, i, itm.Text);
            }
            

            return code;
        }
        */



        public override string ToString()
        {
            return this.Name;
        }


    }
}
