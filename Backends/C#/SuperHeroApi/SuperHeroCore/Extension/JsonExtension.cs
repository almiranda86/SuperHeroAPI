using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Extension
{
    public static class JsonExtension
    {
        public static string ToJson(this object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;
        }

        public static T FromJson<T>(this object obj)
        {
            return JsonConvert.DeserializeObject<T>(obj as string);
        }
    }
}
