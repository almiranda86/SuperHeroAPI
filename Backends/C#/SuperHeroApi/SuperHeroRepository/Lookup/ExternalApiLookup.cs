using AutoMapper;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SuperHeroCore.Infrastructure.Behavior;
using SuperHeroDomain.API;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.CustomModel;
using SuperHeroRepository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Lookup
{
    public class ExternalApiLookup : IExternalApiLookup
    {
        private readonly IMapper _mapper;
        private readonly IRest _rest;
        private readonly IApiConfiguration _apiConfiguration;
        private readonly string apiToken;
        private readonly string apiURI;

        public ExternalApiLookup(IRest rest, IApiConfiguration apiConfiguration, IMapper mapper)
        {
            _rest = rest;
            _apiConfiguration = apiConfiguration;
            apiToken = _apiConfiguration.RetrieveApiToken();
            apiURI = _apiConfiguration.RetrieveApiURL();
            _mapper = mapper;
        }

        public async Task<CompleteHero> GetCompleteHeroById(int heroId)
        {
            var restResponse = await _rest.DoRestCall($"{apiURI}{apiToken}", heroId.ToString());

            ApiResponseModel apiResponseModel = JsonConvert.DeserializeObject<ApiResponseModel>(restResponse);

            CompleteHero completeHero = _mapper.Map<ApiResponseModel, CompleteHero>(apiResponseModel);

            return completeHero;
        }
    }
}
