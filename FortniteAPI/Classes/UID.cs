﻿using System;

using Newtonsoft.Json;

public class UID
{
    string uid; 

    public UID(string _uid)
    {
        uid = _uid;
    }

    public override string ToString()
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

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return new UID(Convert.ToString(reader.Value));
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
