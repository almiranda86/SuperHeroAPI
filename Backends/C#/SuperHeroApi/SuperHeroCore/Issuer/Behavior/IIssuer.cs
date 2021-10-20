using SuperHeroCore.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore.Issuer.Behavior
{
    public interface IIssuer
    {
        string Prefix { get; }
        string MakerCode(Issues issue);
        string MakerProtocol(Issues issue);
    }
}
