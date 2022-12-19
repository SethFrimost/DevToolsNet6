namespace DevToolsNet.DB.Objects
{
    public class DataColumn
    {
        public string name { get; set; }

        public string system_type { get; set; }

        public int system_type_id { get; set; }

        public int max_length { get; set; }

        public int precision { get; set; }

        public int scale { get; set; }

        public bool is_nullable { get; set; }

        public bool is_identity { get; set; }

        public bool is_primary_key { get; set; }

    }
}
