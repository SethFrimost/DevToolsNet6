using System.Collections.Generic;

namespace DevToolsNet.DB.Objects
{
  public class TableIndex
  {
    public string Name { get; set; }

    public bool IsUnique { get; set; }

    public List<DataColumn> Columnas { get; set; }
  }
}
