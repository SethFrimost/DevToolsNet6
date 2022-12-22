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
        public TemplateItemType ItemType { get; set; }
        public string Text { get; set; }

        public bool PK { get; set; }
        public bool NoPK { get; set; }
        public bool Identity { get; set; }
        public bool NoIdentity { get; set; }
        public bool TimeStamp { get; set; }
        public bool NoTimeStamp { get; set; }
        public bool IndexUK { get; set; }
        public bool IndexEnabled { get; set; }
        
        public string TrimText { get; set; }

        public TemplateItem? Parent { get; set; }
        public List<TemplateItem> Childrens { get; set; } = new List<TemplateItem>();


        /*
        public TemplateItem(XElement xmlElement)
        {
            load(xmlElement);
        }

        public TemplateItem(XText xmlText)
        {
            load(xmlText);
        }

        public TemplateItem(XText xmlText, TemplateItem parent)
        {
            Parent = parent;
            load(xmlText);
        }

        public TemplateItem(XElement xmlElement, TemplateItem parent)
        {
            Parent = parent;
            load(xmlElement);
        }
        */
    }
}
