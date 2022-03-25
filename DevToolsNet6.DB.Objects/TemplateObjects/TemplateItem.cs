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
        Text, Columns
    }

    public class TemplateItem
    {
        public TemplateItemType ItemType { get; private set; }
        public string Text { get; private set; }

        public bool Identity { get; private set; }
        public bool NoIdentity { get; private set; }
        public bool TimeStamp { get; private set; }
        public bool NoTimeStamp { get; private set; }


        public TemplateItem(XElement xmlElement)
        {
            if (xmlElement.Name.LocalName.ToLower() == "columns") ItemType = TemplateItemType.Columns;
            else ItemType = TemplateItemType.Text;

            Identity = false;
            NoIdentity = false;
            TimeStamp = false;
            NoTimeStamp = false;

            var opt = xmlElement.Attributes("opts").FirstOrDefault();
            if (opt != null)
            {
                var opts = opt.Value.Split(' ');

                foreach (var o in opts)
                {
                    switch (o)
                    {
                        case "identity": Identity = true; break;
                        case "noidentity": NoIdentity = true; break;
                        case "timestamp": TimeStamp = true; break;
                        case "notimestamp": NoTimeStamp = true; break;
                    }
                }
            }
            Text= xmlElement.Value ?? String.Empty;
        }
    }
}
