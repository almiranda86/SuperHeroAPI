using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Powerstats
    {
        [JsonProperty("intelligence")]
        public string Intelligence { get; set; }

        [JsonProperty("strength")]
        public string Strength { get; set; }

        [JsonProperty("speed")]
        public string Speed { get; set; }

        [JsonProperty("durability")]
        public string Durability { get; set; }

        [JsonProperty("power")]
        public string Power { get; set; }

        [JsonProperty("combat")]
        public string Combat { get; set; }
    }
}
