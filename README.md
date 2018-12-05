# JsonToKeyValuePairs

Generally JSON is converted to & from definite objects. But I had a requirement where we wished to load json into an array/list where data will be stored in key/value pairs.

* Code to Convert JSON String into following:
1. List<KeyValuePair<String, String>>
2. List< StringField >
3. StringFields

Where, 
  class StringField has two properties, viz. Name & Value.
  StringFields is IEnumerable<StringFields>

I could not find any readymade solution So I created this one.

I hope it may be useful to others too.

Thank you.

