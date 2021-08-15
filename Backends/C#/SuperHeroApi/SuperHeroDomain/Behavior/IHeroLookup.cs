using SuperHeroDomain.HeroMaster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroLookup
    {
        Task<IEnumerable<Hero>> GetAll();
    }
}
