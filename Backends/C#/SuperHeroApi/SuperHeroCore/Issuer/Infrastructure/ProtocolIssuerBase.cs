using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperHeroCore.Issuer.Infrastructure
{
    public class ProtocolIssuerBase
    {
        public IssuerData IssuerData { get; set; }

        public string Prefix => IssuerData?.Prefix;
        public virtual string MakerCode(string issue) => ExtractCode(issue);
        public virtual string MakerProtocol(string issue)
        {
            IssuerData.IssuerNumber = ExtractCode(issue);
            return $"{IssuerData.ProjectAcronym}.{IssuerData.ProjectName}.{IssuerData.IssuerNumber}";
        }

        string ExtractCode(string issue) => issue.Split().Last();
    }
}
