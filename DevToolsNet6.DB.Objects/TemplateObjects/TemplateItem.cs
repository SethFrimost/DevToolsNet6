using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DevToolsNet.DB.Objects.TemplateObjects
{
    public enum TemplateItemType
    {
        Text, Columns, Index, IndexColumns
    }

    public class TemplateItem
    {
        public TemplateItemType ItemType { get; private set; }
        public string Text { get; private set; }

        public bool PK { get; private set; }
        public bool NoPK { get; private set; }
        public bool Identity { get; private set; }
        public bool NoIdentity { get; private set; }
        public bool TimeStamp { get; private set; }
        public bool NoTimeStamp { get; private set; }
        public bool IndexUK { get; private set; }
        public bool IndexEnabled { get; private set; }
        
        public string TrimText { get; private set; }

        public TemplateItem? Parent { get; private set; }
        public List<TemplateItem> Childrens { get; private set; } = new List<TemplateItem>();


        public TemplateItem(XElement xmlElement)
        {
            load(xmlElement);
        }

        public TemplateItem(XElement xmlElement, TemplateItem parent)
        {
            Parent = parent;
            load(xmlElement);
        }


        private void load(XElement xmlElement)
        {
            if (xmlElement.Name.LocalName.ToLower() == "columns" || xmlElement.Name.LocalName.ToLower() == "c") ItemType = TemplateItemType.Columns;
            else if (xmlElement.Name.LocalName.ToLower() == "indexcolumns" || xmlElement.Name.LocalName.ToLower() == "ic") ItemType = TemplateItemType.IndexColumns;
            else if (xmlElement.Name.LocalName.ToLower() == "index" || xmlElement.Name.LocalName.ToLower() == "i") ItemType = TemplateItemType.Index;
            else ItemType = TemplateItemType.Text;


            if (ItemType == TemplateItemType.IndexColumns && xmlElement.Parent != null && Parent == null) Parent = new TemplateItem(xmlElement.Parent);
            
            itemOptions(xmlElement);

            var trim = xmlElement.Attributes("trim").FirstOrDefault();
            if (trim != null) TrimText = trim.Value;
            else TrimText = string.Empty;

            if (ItemType == TemplateItemType.Index && xmlElement.HasElements)
                Text = xmlElement.FirstNode?.ToString() ?? String.Empty;
            else
                Text = xmlElement.Value ?? String.Empty;


        }

        private void itemOptions(XElement xmlElement)
        {
            var opt = xmlElement.Attributes("opts").FirstOrDefault();

            PK = false;
            NoPK = false;
            Identity = false;
            NoIdentity = false;
            TimeStamp = false;
            NoTimeStamp = false;
            IndexUK = false;
            IndexEnabled = false;

            if (opt != null)
            {
                var opts = opt.Value.Split(' ');

                foreach (var o in opts)
                {
                    switch (o.ToLower())
                    {
                        case "pk": PK = true; break;
                        case "nopk": NoPK = true; break;
                        case "identity": Identity = true; break;
                        case "noidentity": NoIdentity = true; break;
                        case "timestamp": TimeStamp = true; break;
                        case "notimestamp": NoTimeStamp = true; break;
                        case "indexuk": IndexUK = true; break;
                        case "indexenabled": IndexEnabled = true; break;
                    }
                }
            }
        }
    }
}
