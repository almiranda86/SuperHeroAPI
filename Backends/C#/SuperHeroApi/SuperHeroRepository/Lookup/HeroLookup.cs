using SuperHeroDomain.Behavior;
using SuperHeroDomain.HeroMaster;
using SuperHeroRepository.Behavior;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroRepository.Lookup
{
    public class HeroLookup : IHeroLookup
    {
        private readonly IDbSession _session;

        public HeroLookup(IDbSession session)
        {
            _session = session;
        }

        public Task<IEnumerable<Hero>> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}