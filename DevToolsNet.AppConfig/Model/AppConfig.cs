

using System;

namespace DevToolsNet.AppConfig
{
    public class AppConfig
    {
        public Guid Id { get; set; }
        public string App { get; set; }
        public string Group { get; set; }
        public string PC { get; set; }
        public string Name { get; set; }    
        public string Value { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}