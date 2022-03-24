using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DevToolsNet.DB.Generator
{
  public class PlantillaGenerador
  {
    private List<PlantillaGenerador.Nodo> roots;

    public PlantillaGenerador(string data, bool isFile = true)
    {
      XDocument xdocument = !isFile ? XDocument.Parse(data) : XDocument.Load(data);
      this.roots = new List<PlantillaGenerador.Nodo>();
      this.agregarNodos((PlantillaGenerador.Nodo) null, xdocument.Elements());
    }

    private void agregarNodos(PlantillaGenerador.Nodo nodo, IEnumerable<XElement> Elements)
    {
      foreach (XElement element in Elements)
      {
        PlantillaGenerador.Nodo nodo1 = new PlantillaGenerador.Nodo();
        switch (element.Name.LocalName)
        {
          case "tabla":
            nodo1.Tipo = PlantillaGenerador.TipoNodo.tabla;
            this.agregarNodos(nodo1, element.Elements());
            break;
          case "columnas":
            nodo1.Tipo = PlantillaGenerador.TipoNodo.columnas;
            nodo1.Texto = element.Value;
            break;
          case "texto":
            nodo1.Tipo = PlantillaGenerador.TipoNodo.texto;
            nodo1.Texto = element.Value;
            break;
        }
        foreach (XAttribute attribute in element.Attributes())
          nodo1.propiedades.Add(new KeyValuePair<string, string>(attribute.Name.LocalName, attribute.Value));
        if (nodo == null)
          this.roots.Add(nodo1);
        else
          nodo.SubNodos.Add(nodo1);
      }
    }

    public string ProcesarPlantilla(List<DataTable> tablas)
    {
      StringBuilder resultado = new StringBuilder();
      this.roots.ForEach((Action<PlantillaGenerador.Nodo>) (n => resultado.Append(this.procesarNodo(n, tablas))));
      return resultado.ToString();
    }

    private string procesarNodo(PlantillaGenerador.Nodo n, List<DataTable> tablas)
    {
      StringBuilder res = new StringBuilder();
      if (n.Tipo == PlantillaGenerador.TipoNodo.tabla)
        tablas.ForEach((Action<DataTable>) (t => res.Append(this.procesarNodo(n, t))));
      else if (n.Tipo == PlantillaGenerador.TipoNodo.texto)
        res.Append(n.Texto);
      return res.ToString();
    }

    private string procesarNodo(PlantillaGenerador.Nodo n, DataTable tabla)
    {
      StringBuilder res = new StringBuilder();
      bool flag1 = n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.onlyIdentity.ToString().ToLower()));
      bool flag2 = n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.noIdentity.ToString().ToLower()));
      if (!flag1 && !flag2 || (flag1 && tabla.Columnas.Any<DataColumn>((Func<DataColumn, bool>) (c => c.is_identity)) || flag2 && !tabla.Columnas.Any<DataColumn>((Func<DataColumn, bool>) (c => c.is_identity))))
        n.SubNodos.ForEach((Action<PlantillaGenerador.Nodo>) (sn =>
        {
          if (sn.Tipo == PlantillaGenerador.TipoNodo.tabla)
            res.Append(this.procesarNodo(sn, tabla));
          else if (sn.Tipo == PlantillaGenerador.TipoNodo.columnas)
          {
            res.Append(this.procesarNodo(sn, tabla.Columnas));
          }
          else
          {
            if (sn.Tipo != PlantillaGenerador.TipoNodo.texto)
              return;
            res.Append(this.procesarTexto(sn.Texto, tabla));
          }
        }));
      return res.ToString();
    }

    private string procesarNodo(PlantillaGenerador.Nodo n, List<DataColumn> columns)
    {
      bool onlyIdentity = n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.onlyIdentity.ToString().ToLower()));
      bool noIncuriIdentity = n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.noIdentity.ToString().ToLower()));
      bool noIncluirTimeStamp = n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.noTimestamp.ToString().ToLower()));
      StringBuilder res = new StringBuilder();
      columns.ForEach((Action<DataColumn>) (c =>
      {
        if (onlyIdentity)
        {
          if (!c.is_identity)
            return;
          res.Append(this.procesarTexto(n.Texto, c));
        }
        else
        {
          if (noIncuriIdentity && c.is_identity || noIncluirTimeStamp && c.system_type == "timestamp")
            return;
          res.Append(this.procesarTexto(n.Texto, c));
        }
      }));
      if (!n.propiedades.Any<KeyValuePair<string, string>>((Func<KeyValuePair<string, string>, bool>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.trim.ToString().ToLower())))
        return res.ToString();
      string str = n.propiedades.Find((Predicate<KeyValuePair<string, string>>) (x => x.Key.ToLower() == PlantillaGenerador.Atributos.trim.ToString().ToLower())).Value;
      return res.ToString().Trim(str.ToCharArray());
    }

    private string procesarTexto(string text, DataTable tabla) => (text ?? string.Empty).Replace("\n", "\r\n").Replace("{tabla}", tabla.Tabla).Replace("{schema}", tabla.Schema);

    private string procesarTexto(string text, DataColumn columna) => (text ?? string.Empty).Replace("\n", "\r\n").Replace("{columna}", columna.Columna).Replace("{colType}", this.getTextColumnType(columna));

    private string getTextColumnType(DataColumn columna)
    {
      if (columna.system_type.Contains("char"))
        return string.Format("{0}({1})", (object) columna.system_type, columna.max_length == -1 ? (object) "MAX" : (object) columna.max_length.ToString());
      return columna.system_type == "decimal" ? string.Format("{0}({1},{2})", (object) columna.system_type, (object) columna.max_length, (object) columna.scale) : columna.system_type;
    }

    private string getTextCType(DataColumn columna)
    {
      if (columna.system_type.Contains("char"))
        return "string";
      if (columna.system_type == "decimal")
        return columna.is_nullable ? "decimal?" : "decimal";
      if (columna.system_type == "bigint")
        return columna.is_nullable ? "long?" : "long";
      if (columna.system_type == "int")
        return columna.is_nullable ? "int?" : "int";
      if (columna.system_type.Contains("date"))
        return columna.is_nullable ? "datetime?" : "datetime";
      if (columna.system_type.Contains("timestamp"))
        return columna.is_nullable ? "byte[]?" : "byte[]";
      if (!columna.system_type.Contains("bit"))
        return "noType";
      return columna.is_nullable ? "bool?" : "bool";
    }

    private enum TipoNodo
    {
      tabla,
      columnas,
      texto,
    }

    private enum Atributos
    {
      onlyIdentity,
      noIdentity,
      noTimestamp,
      trim,
    }

    private class Nodo
    {
      public PlantillaGenerador.TipoNodo Tipo { get; set; }

      public string Texto { get; set; }

      public List<PlantillaGenerador.Nodo> SubNodos { get; set; }

      public List<KeyValuePair<string, string>> propiedades { get; set; }

      public Nodo()
      {
        this.SubNodos = new List<PlantillaGenerador.Nodo>();
        this.propiedades = new List<KeyValuePair<string, string>>();
      }
    }
  }
}
