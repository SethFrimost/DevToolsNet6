using DevToolsNet.Shared.Interfaces;
using System.Text.Json;

namespace DevToolsNet.Json
{
    public partial class JsonSerializer : ISerializer
    {
        public T Deserialize<T>(string data)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(data);
        }

        public string Serialize<T>(T o)
        {
            return System.Text.Json.JsonSerializer.Serialize(o);
        }
    }
}