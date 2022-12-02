using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevToolsNet.WinFormsControlLibrary.Style
{
    internal class ColorHexJsonConverter : JsonConverter<Color>
    {
        ColorConverter cc = new ColorConverter();

        public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var s = reader.GetString();
            if (s == null) return Color.Empty;
            else return (Color)cc.ConvertFromString(s);
        }

        public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
        {
            if (value == Color.Empty) writer.WriteNullValue();
            else writer.WriteStringValue(cc.ConvertToString(value));
        }
    }
}
