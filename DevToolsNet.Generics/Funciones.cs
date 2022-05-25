using DevToolsNet.Extensions;

namespace DevToolsNet.Generics
{
    public class Funciones
    {
        /// <summary>Crea y traspasa los datos de las propiedades con el mismo nombre y tipo</summary>
        /// <typeparam name="T">Tipo destino</typeparam>
        /// <typeparam name="T2">Tipo origen</typeparam>
        /// <param name="origen">Objeto de donde se trasparán los datos</param>
        /// <returns>Nuevo objeto de tipo "T2" con los valores del origen</returns>
        public static T ObjectToObject<T, T2>(T2 origen) where T : new()
        {
            T res = new T();
            var tipoRes = typeof(T);
            var tipoIn = typeof(T2);
            var props = tipoIn.GetProperties().FindAllToList(x => tipoRes.GetProperties().Any(y => y.Name == x.Name && y.PropertyType == x.PropertyType));
            foreach (var p in props)
            {
                var pd = tipoRes.GetProperty(p.Name);
                pd.SetValue(res, p.GetValue(origen, null), null);
            }
            return res;
        }

        /// <summary>
        /// Replace all properties into text. Using {propertieName} for replace pattern
        /// </summary>
        /// <param name="textoFormato">String format. Ex; "Hi {Name}, ... " </param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string StringReplaceProperites(string textoFormato, object obj)
        {
            string res = string.Empty;
            if (obj != null && !string.IsNullOrEmpty(textoFormato))
            {
                var t = obj.GetType();
                foreach (var p in t.GetProperties())
                    res = res.Replace("{" + p.Name + "}", p.GetValue(obj, null)?.ToString()?.Trim() ?? string.Empty);
            }
            return res;
        }
    }


    
}