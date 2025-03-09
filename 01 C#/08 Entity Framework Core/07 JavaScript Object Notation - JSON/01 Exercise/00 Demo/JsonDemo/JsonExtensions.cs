using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace JsonDemo
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        public static T? FromJson<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, jsonSerializerOptions);
        }

        public static string ToJson<T>(this T obj)
        {
            return JsonSerializer.Serialize(obj, jsonSerializerOptions);
        }

        public static T? FromJson<T>(this string json, JsonSerializerOptions options)
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }

        public static string ToJson<T>(this T obj, JsonSerializerOptions options)
        {
            return JsonSerializer.Serialize(obj, options);
        }
    }
}
