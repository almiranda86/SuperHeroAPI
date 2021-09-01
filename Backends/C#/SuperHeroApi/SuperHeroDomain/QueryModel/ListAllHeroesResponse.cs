using SuperHeroCore;
using SuperHeroDomain.BaseModel;
using SuperHeroDomain.HeroMaster;
using System;
using System.Collections.Generic;
using System.Text;

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
