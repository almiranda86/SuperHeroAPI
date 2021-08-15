using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Model
{
    public class Biography
    {
        public string FullName { get; set; }
        public List<string> AlterEgos { get; set; }
        public List<string> Aliases { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FirstAppearance { get; set; }
        public string Publisher { get; set; }
        public string Alignment { get; set; }
    }
}
