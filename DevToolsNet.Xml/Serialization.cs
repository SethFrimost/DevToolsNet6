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

    public class Serialization
    {

        /// <summary>
        ///     Recibe un objeto y lo serializa en XML
        /// </summary>
        /// <param name=”_oObjetoToSerialize”>Objeto que será serializado</param>
        /// <returns>String con la información del objeto en formato XML</returns>
        public static string GetObjectSerialized(object _oObjetoToSerialize)
        {
            string sRes = string.Empty;

            try
            {
                StringBuilder sbStringBuilder = new StringBuilder();

                using (StringWriter swStringWriter = new StringWriter(sbStringBuilder))
                {
                    XmlSerializer oXmlSerializer = new XmlSerializer(_oObjetoToSerialize.GetType());
                    oXmlSerializer.Serialize(swStringWriter, _oObjetoToSerialize);
                    sRes = swStringWriter.ToString();
                }

                return sRes;
            }
            catch
            {
                //– Gestor de errores
                throw;
            }
        }


        /// <summary>
        ///     Recibe un objeto y lo serializa en XML
        /// </summary>
        /// <param name=”_oObjetoToSerialize”>Objeto que será serializado</param>
        /// <returns>String con la información del objeto en formato XML</returns>
        public static string GetObjectSerialized(object _oObjetoToSerialize, Encoding encoding)
        {
            string sRes = string.Empty;

            try
            {
                Encoding xml = Encoding.UTF8;
                StringBuilder sbStringBuilder = new StringBuilder();

                using (StringWriter swStringWriter = new StringWriter(sbStringBuilder))
                {
                    XmlSerializer oXmlSerializer = new XmlSerializer(_oObjetoToSerialize.GetType());
                    oXmlSerializer.Serialize(swStringWriter, _oObjetoToSerialize);
                    sRes = swStringWriter.ToString();
                }

                byte[] unicodeBytes = xml.GetBytes(sRes);

                return encoding.GetString(unicodeBytes);
            }
            catch
            {
                //– Gestor de errores
                throw;
            }
        }

        //TODO -- Pruebas 
        /// <summary>
        ///     Recibe un archivo XML y lo transforma en un string.
        /// </summary>
        /// <param name="_sXML_Load">string: ruta completa del archivo</param>
        /// <returns>string</returns>
        public static string GetObjectSerialized(string _sXML_Load)
        {
            XmlDocument xDoc = new XmlDocument();
            XDocument xD = XDocument.Load(_sXML_Load);

            xDoc.Load(_sXML_Load);
            string sResultado = xDoc.InnerXml;
            xDoc = null;

            return sResultado;
        }


        /// <summary>
        ///     Devuelve el objeto recibido dentro del XML.
        /// </summary>
        /// <param name="oToDeserializeObjectoType">object</param>
        /// <param name="sXML">string</param>
        /// <returns>object</returns>
        public static T GetObjectDeserialized<T>(string sXML)
        {
            T oObject = default(T);

            try
            {
                using (XmlTextReader oReader = new XmlTextReader(new StringReader(sXML)))
                {
                    //-- Deserializa Objetos con XML
                    XmlSerializer oSerializer = new XmlSerializer(typeof(T));
                    oObject = (T)oSerializer.Deserialize(oReader);
                }
            }
            catch (Exception ex)
            {
                //--  Gestor de errores
            }

            return oObject;
        }


        /// <summary>
        ///     Devuelve el objeto recibido dentro del XML.
        /// </summary>
        /// <param name="oToDeserializeObjectoType">object</param>
        /// <param name="sXML">string</param>
        /// <param name="defNamespace">string</param>
        /// <returns>object</returns>
        public static T GetObjectDeserialized<T>(string sXML, string defNamespace)
        {
            T oObject = default(T);

            try
            {
                using (XmlTextReader oReader = new XmlTextReader(new StringReader(sXML)))
                {
                    //-- Deserializa Objetos con XML
                    XmlSerializer oSerializer = new XmlSerializer(typeof(T), defNamespace);
                    oObject = (T)oSerializer.Deserialize(oReader);
                }
            }
            catch
            {
                //--  Gestor de errores
            }

#pragma warning disable CS8603 // Posible tipo de valor devuelto de referencia nulo
            return oObject;
#pragma warning restore CS8603 // Posible tipo de valor devuelto de referencia nulo
        }


        public static string DataContractSerialize(object obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using (var output = new StringWriter())
            using (var writer = new XmlTextWriter(output) { Formatting = Formatting.Indented })
            {
                serializer.WriteObject(writer, obj);
                return output.GetStringBuilder().ToString();
            }
        }

        public static T DataContractDeserialize<T>(string xml)
        {
            using (Stream stream = new MemoryStream())
            {
                byte[] data = System.Text.Encoding.UTF8.GetBytes(xml);
                stream.Write(data, 0, data.Length);
                stream.Position = 0;
                DataContractSerializer deserializer = new DataContractSerializer(typeof(T));
                return (T)deserializer.ReadObject(stream);
            }
        }




    }
}
