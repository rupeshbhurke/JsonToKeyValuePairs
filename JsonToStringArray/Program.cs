using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonToStringArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"Name\": \"Intel\",\"PSU\": \"500W\"}";

            List<KeyValuePair<string, string>> pairs;
            if (!JsonHelper.ConvertToKeyValuePairs(json, out pairs))
            {
                Console.WriteLine("Invalid JSON");
            }

            foreach (KeyValuePair<string, string> pair in pairs)
            {
                Console.WriteLine("Name: {0}, Value: {1}", pair.Key, pair.Value);
            }


            Console.WriteLine("From StringFields class");
            var sfs = new StringFields(json);
            foreach (StringField sf in sfs)
            {
                Console.WriteLine("Name: {0}, Value: {1}", sf.Name, sf.Value);
            }
        }
    }
}
