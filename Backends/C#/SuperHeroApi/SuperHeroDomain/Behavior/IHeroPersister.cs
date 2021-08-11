using SuperHeroRepository.HeroMaster;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroPersister
    {
        Task Create(Hero hero);
    }
}
