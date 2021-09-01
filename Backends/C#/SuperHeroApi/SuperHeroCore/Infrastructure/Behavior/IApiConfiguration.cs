using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroCore.Infrastructure.Behavior
{
    public interface IApiConfiguration
    {
        string RetrieveApiToken();
        string RetrieveApiURL();
        string RetrieveDataBaseName();
    }
}
