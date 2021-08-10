using Dapper;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using SuperHeroRepository.HeroMaster;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Persister
{
    public class HeroPersister : IHeroPersister
    {
        private readonly DbSession _session;

        public HeroPersister(DbSession session)
        {
            _session = session;
        }

        public async Task Create(Hero hero)
        {
            await _session.Connection.ExecuteAsync("INSERT INTO Hero (API_ID, Name) VALUES (@API_ID, @Name);", hero, _session.Transaction);
        }
    }
}
