﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevToolsNet.zzzTester
{
    internal class Grupo
    {
        public Grupo padre { get; set; } = null;
        public string name { get; set; } = null;

        public Color color { get; set; }
        public List<Grupo> subGrupos { get; set; } = null;
    }


    internal class Estilo
    {
        [JsonConverter(typeof(ColorHexJsonConverter))]
        public Color a { get; set; }

        [JsonConverter(typeof(ColorHexJsonConverter))]
        public Color b { get; set; }

    }


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
