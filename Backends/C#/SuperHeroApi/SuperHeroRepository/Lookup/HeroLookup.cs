using Dapper;
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

        public async Task<int> GetCountHeroes()
        {
            var result = await _session.Connection.QuerySingleAsync<int>(@"SELECT COUNT(PUBLIC_ID) FROM Hero;", _session.Transaction);

            return result;
        }
    }
}