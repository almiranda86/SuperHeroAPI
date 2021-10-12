using SuperHeroDomain.HeroMaster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroLookup
    {
        Task<List<Hero>> GetAll();
        Task<int> GetCountHeroes();
        Task<Hero> GetHeroByPublicId(string publicHeroId);
        Task<List<Hero>> GetAllHeroesPaginated(int? initPage, int? endPage);
    }
}
