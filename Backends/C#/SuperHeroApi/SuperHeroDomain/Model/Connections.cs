using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Connections
    {
        [JsonProperty("group-affiliation")]
        public string GroupAffiliation { get; set; }

        [JsonProperty("relatives")]
        public string Relatives { get; set; }
    }
}
