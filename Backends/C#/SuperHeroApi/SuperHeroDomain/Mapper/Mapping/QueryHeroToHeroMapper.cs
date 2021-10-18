using AutoMapper;
using SuperHeroDomain.DapperModel;
using System.Collections.Generic;
using System.Linq;

namespace SuperHeroDomain.Mapper.Mapping
{
    public class QueryHeroToHeroMapper : Profile
    {
        public QueryHeroToHeroMapper()
        {
            CreateMap<QueryHero, Model.HeroMaster.Hero>();

            CreateMap<IEnumerable<QueryHero>, List<Model.HeroMaster.Hero>>().AfterMap((origin, destination) =>
            {
                var listHero = origin.ToList();

                foreach (var hero in listHero)
                {
                    destination.Add(new Model.HeroMaster.Hero()
                    {
                        API_ID = hero.API_ID,
                        NAME = hero.NAME,
                        PUBLIC_ID = hero.PUBLIC_ID
                    });
                }
            });
        }
    }
}