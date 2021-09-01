using AutoMapper;
using SuperHeroDomain.Mapper.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Mapper.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration Register()
        {
            return new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new ApiResponseModelToCompleteHero());
            });
        }
    }
}
