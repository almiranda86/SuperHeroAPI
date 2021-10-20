using SuperHeroCore.Enums;
using SuperHeroCore.Issuer.Behavior;
using SuperHeroCore.Issuer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Issuer
{
    public class Issuer : ProtocolIssuerBase, IIssuer
    {
        public Issuer()
        {
            IssuerData = new IssuerData { ProjectAcronym = "SH", ProjectName = "API" };
        }

        public string MakerCode(Issues issue)
        {
            return MakerCode(issue.ToString());
        }

        public string MakerProtocol(Issues issue)
        {
            return MakerProtocol(issue.ToString());
        }
    }
}
