using Newtonsoft.Json;
using System;

namespace FortniteAPI.Classes
{
    public class UID
    {
        string uid; 

        public UID(string _uid)
        {
            uid = _uid;
        }

        public string GetUID()
        {
            return uid;
        }
    }

    public class UIDConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return new UID((string)reader.Value);
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
