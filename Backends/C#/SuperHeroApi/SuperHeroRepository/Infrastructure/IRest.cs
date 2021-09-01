using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Infrastructure
{
    public interface IRest
    {
        Task<string> DoRestCall(string uri, string uriParams);
    }
}
