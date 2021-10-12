using Dapper;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.HeroMaster;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Lookup.SQL;
using System;
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
            var result = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetAll());

            return result.ToList();
        }

        public async Task<int> GetCountHeroes()
        {
            var result = await _session.Connection.QuerySingleAsync<int>(LookupSQLQueries.GetCountHeroes());

            return result;
        }

        public async Task<Hero> GetHeroByPublicId(string publicHeroId)
        {
            IEnumerable<Hero> result;

            try
            {
                result = await _session.Connection.QueryAsync<Hero>(LookupSQLQueries.GetHeroByPublicId(), new { PUBLIC_ID = publicHeroId });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return result.FirstOrDefault();
        }
    }
}