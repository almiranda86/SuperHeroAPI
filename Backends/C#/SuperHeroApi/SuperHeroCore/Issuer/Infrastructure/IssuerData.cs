using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Issuer.Infrastructure
{
    public class IssuerData
    {
        public string ProjectAcronym { get; set; }
        public string ProjectName { get; set; }
        public string Prefix => $"{ProjectAcronym}.{ProjectName}";
        public string IssuerNumber { get; set; }
    }
}
