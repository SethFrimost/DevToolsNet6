using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Xml.Serialization;

namespace Servicios
{
    [XmlRoot("Server")]
    public class Server
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("IP")]
        public string IP { get; set; }

        [XmlElement("Servicios")]
        public List<string> Servicios { get; set; }

        public Server()
        {
            Servicios = new List<string>();
        }
    }

    public class ServicioEstado
    {
        public string Name { get; set; }
        public ServiceControllerStatus LastStatus { get; set; }
        public ServiceController ServController { get; set; }
    }

}
