using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace JsonToStringArray
{
    public static class JsonHelper
    {
        public static bool
            ConvertToKeyValuePairs( string json, out List<KeyValuePair<string, string>> pairs )
        {
            pairs = null;
            if (string.IsNullOrEmpty(json))
                return false;
            
            JsonTextReader reader = new JsonTextReader(new StringReader(json));
            while (reader.Read())
            {
                string key = string.Empty;
                string value = string.Empty;

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    key = reader.Value.ToString();
                    if (!reader.Read())
                        break;
                    if (reader.TokenType != JsonToken.Comment &&
                        reader.TokenType != JsonToken.EndArray &&
                        reader.TokenType != JsonToken.EndConstructor &&
                        reader.TokenType != JsonToken.EndObject &&
                        reader.TokenType != JsonToken.PropertyName &&
                        reader.TokenType != JsonToken.None &&
                        reader.TokenType != JsonToken.Null &&
                        reader.TokenType != JsonToken.Raw &&
                        reader.TokenType != JsonToken.StartArray &&
                        reader.TokenType != JsonToken.StartConstructor &&
                        reader.TokenType != JsonToken.StartObject &&
                        reader.TokenType != JsonToken.Undefined)
                        value = reader.Value.ToString();
                    if ( pairs == null)
                        pairs = new List<KeyValuePair<string,string>>();
                    pairs.Add( new KeyValuePair<string, string>( key, value));
                }
            }
            return pairs != null && pairs.Any();
        }
    }
}
