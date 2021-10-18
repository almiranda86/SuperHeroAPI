using SuperHeroCore;
using SuperHeroDomain.Model.HeroMaster;
using System.Collections.Generic;

namespace SuperHeroDomain.QueryModel
{
    public class ListAllHeroesResponse : ServiceResponse
    {
        public List<Hero> Heroes { get; set; }

        public ListAllHeroesResponse()
        {
            Heroes = new List<Hero>();
        }
    }
}
