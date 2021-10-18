using System;
using System.Text.Json.Serialization;

namespace SuperHeroDomain.Model.HeroMaster
{
    public class Hero
    {
        [JsonIgnore]
        public int ID { get; set; }
        public Guid PUBLIC_ID { get; set; }

        [JsonIgnore]
        public int API_ID { get; set; }
        public string NAME { get; set; }

    }
}
