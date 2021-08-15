using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Appearance
    {
        public string Gender { get; set; }
        public string Race { get; set; }
        public List<string> Height { get; set; }
        public List<string> Weight { get; set; }
        public string EyeColor { get; set; }
        public string HairColor { get; set; }
    }
}
