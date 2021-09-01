using Dapper;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.HeroMaster;
using SuperHeroRepository.Behavior;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Hero>> GetAll()
        {
            var result = await _session.Connection.QueryAsync<Hero>(@"SELECT PUBLIC_ID, NAME FROM Hero;", _session.Transaction);

            return result.ToList();
        }

        public async Task<int> GetCountHeroes()
        {
            var result = await _session.Connection.QuerySingleAsync<int>(@"SELECT COUNT(PUBLIC_ID) FROM Hero;", _session.Transaction);

            return result;
        }

        public async Task<Hero> GetHeroByPublicId(string publicHeroId)
        {
            var result = await _session.Connection.QueryAsync<Hero>(@"SELECT PUBLIC_ID, NAME, API_ID FROM Hero WHERE PUBLIC_ID = @PUBLIC_ID;", new { PUBLIC_ID = publicHeroId }, _session.Transaction);

            return result.FirstOrDefault();
        }
    }
}