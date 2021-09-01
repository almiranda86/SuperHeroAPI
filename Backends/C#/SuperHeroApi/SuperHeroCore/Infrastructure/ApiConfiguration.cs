using Microsoft.Extensions.Configuration;
using SuperHeroCore.Infrastructure.Behavior;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroCore.Infrastructure
{
    public class ApiConfiguration : IApiConfiguration
    {
        private readonly IConfiguration _configuration;
        public ApiConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string RetrieveApiToken()
        {
            var apiToken = _configuration["ApiToken"];
            return apiToken;
        }

        public string RetrieveApiURL()
        {
            var apiURI = _configuration["ApiURL"];
            return apiURI;
        }

        public string RetrieveDataBaseName()
        {
            var databaseName = _configuration["DatabaseName"];
            return databaseName;
        }
    }
}
