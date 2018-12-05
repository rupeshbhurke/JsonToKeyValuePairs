using System;
using System.Collections;
using System.Collections.Generic;

namespace JsonToStringArray
{
    public class StringFields : IEnumerable<StringField>
    {
        protected List<StringField> Pairs;

        public StringFields(string json)
        {
            List<KeyValuePair<string, string>> pairs;
            JsonHelper.ConvertToKeyValuePairs(json, out pairs);
            Initialize(pairs);
        }

        public StringFields(List<StringField> pairs)
        {
            Pairs = pairs;
        }

        public StringFields(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            Initialize(pairs);
        }

        public IEnumerator<StringField> GetEnumerator()
        {
            return Pairs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void ForEach(Action<StringField> action)
        {
            foreach (StringField pair in Pairs)
            {
                action(pair);
            }
        }

        protected virtual void Initialize(IEnumerable<KeyValuePair<string, string>> pairs)
        {
            Pairs = new List<StringField>();
            foreach (var p in pairs)
            {
                Pairs.Add(new StringField(p.Key, p.Value));
            }
        }
    }
}
