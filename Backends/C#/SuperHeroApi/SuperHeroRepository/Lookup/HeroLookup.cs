using Dapper;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using SuperHeroRepository.HeroMaster;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Lookup
{
    public class HeroLookup : IHeroLookup
    {
        private readonly DbSession _session;

        public HeroLookup(DbSession session)
        {
            _session = session;
        }


        public async Task<IEnumerable<Hero>> GetAll()
        {
            return await _session.Connection.QueryAsync<Hero>("SELECT rowid AS Id, API_ID, Name FROM Hero;");
        }
    }
}