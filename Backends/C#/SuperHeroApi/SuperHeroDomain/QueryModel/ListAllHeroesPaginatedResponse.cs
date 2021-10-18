using SuperHeroDomain.Infrastructure.Query;
using SuperHeroDomain.Model.HeroMaster;
using System.Collections.Generic;

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
