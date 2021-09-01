using AutoMapper;
using SuperHeroDomain.API;
using SuperHeroDomain.CustomModel;
using System;

namespace SuperHeroDomain.Mapper.Mapping
{
   public class ApiResponseModelToCompleteHero : Profile
    {
        public ApiResponseModelToCompleteHero()
        {
            CreateMap<ApiResponseModel, CompleteHero>();
        }
    }
}