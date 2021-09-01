using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Work
    {
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        [JsonProperty("base")]
        public string BaseOfOperation { get; set; }
    }
}
