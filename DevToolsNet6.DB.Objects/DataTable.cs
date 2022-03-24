using System.Collections.Generic;

namespace DevToolsNet.DB.Objects
{
  public class DataTable
  {
    public string Schema { get; set; }

    public string Tabla { get; set; }

    public List<DataColumn> Columnas { get; set; }
  }
}
