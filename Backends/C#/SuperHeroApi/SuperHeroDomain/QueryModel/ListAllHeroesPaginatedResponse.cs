using SuperHeroCore;
using SuperHeroDomain.BaseModel;
using SuperHeroDomain.HeroMaster;
using SuperHeroDomain.Infrastructure.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.QueryModel
{
    public class ListAllHeroesPaginatedResponse : PagedServiceResponseBase
    {
        public List<Hero> Heroes { get; set; }

        public ListAllHeroesPaginatedResponse()
        {
            Heroes = new List<Hero>();
        }
    }
}
