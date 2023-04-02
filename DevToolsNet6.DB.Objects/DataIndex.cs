namespace DevToolsNet.DB.Objects
{
    public class DataIndex
    {
        public string name { get; set; }

        public bool is_identity { get; set; }

        public bool is_primary_key { get; set; }

        public bool is_unique { get; set; }

        public bool is_disabled { get; set; }

        public List<DataColumn> Columnas { get; set; }
    }
}
