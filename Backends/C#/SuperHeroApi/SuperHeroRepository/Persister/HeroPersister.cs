using Dapper;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.HeroMaster;
using SuperHeroRepository.Behavior;
using System.Threading.Tasks;

namespace SuperHeroRepository.Persister
{
    public class HeroPersister : IHeroPersister
    {
        private readonly IDbSession _session;

        public HeroPersister(IDbSession session)
        {
            _session = session;
        }

        public async Task Create(Hero hero)
        {
            await _session.Connection.ExecuteAsync("INSERT INTO Hero (API_ID, Name) VALUES (@API_ID, @Name);", hero, _session.Transaction);
        }
    }
}
