using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Infrastructure
{
    public class Rest : IRest
    {
        public async Task<string> DoRestCall(string uri, string uriParams)
        {
            var fullPath = $"{uri}/{uriParams}";

            var client = new RestClient(fullPath);
            var RSClient = new RestRequest(Method.GET) { RequestFormat = DataFormat.Json };

            IRestResponse restResponse = await client.ExecuteAsync(RSClient);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
                return restResponse.Content;

            return string.Empty;
        }
    }
}
