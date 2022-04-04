using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;


namespace DevToolsNet.Extensions
{

    public static class StringExtenders
    {

        /// <summary>Use string as string format for parameters</summary>
        /// <param name="x"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Format(this string x, params object[] args)
        {
            return string.Format(x, args);
        }


        /// <summary>
        /// Método extensor asociado a un string que devuelve un entero
        /// </summary>
        /// <param name="cadena">this string</param>
        /// <param name="valorXdefecto">int</param>
        /// <returns>int</returns>
        public static int ToInteger(this string cadena, int valorXdefecto)
        {
            int result = valorXdefecto;

            try
            {
                result = Convert.ToInt32(cadena);
            }
            catch { }

            return result;
        }


        /// <summary>
        /// Sobrecarga del método extensor. Si no pasamos el 2º parámetro, se asume 0
        /// </summary>
        /// <param name="cadena">this string</param>
        /// <returns>int</returns>
        public static int ToInteger(this string cadena)
        {
            return ToInteger(cadena, 0);
        }


        /// <summary>Try to convert to date</summary>
        /// <param name="x">string</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string x)
        {
            DateTime dt;
            if (DateTime.TryParse(x, out dt))
            {
                return dt;
            }
            else
            {
                return null;
            }

        }


        public static string ReplaceValues(this string txt, object data, string openTag = "{", string closeTag = "}")
        {
            string res = txt;
            var props = data.GetType().GetProperties();
            foreach (var p in props)
            {
                res = res.Replace(openTag + p.Name + closeTag, p.GetValue(data)?.ToString() ?? string.Empty);
            }
            return res;
        }


        public static Stream GenerateStreamFromString(this string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

    }
}
