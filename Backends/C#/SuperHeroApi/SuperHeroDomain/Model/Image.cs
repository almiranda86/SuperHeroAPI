using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Image
    {
        [JsonProperty("url")]
        public string URL { get; set; }
    }
}
