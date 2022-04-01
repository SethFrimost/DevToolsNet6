using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;


namespace DevToolsNet.Xml
{
    public class XmlObjectSerializer : Shared.Interfaces.ISerializer
    {
        public T Deserialize<T>(string data)
        {
            return Serialization.GetObjectDeserialized<T>(data);
        }

        public string Serialize<T>(T o)
        {
            return Serialization.GetObjectSerialized(o); 
        }
    }
}
