using SuperHeroRepository.HeroMaster;
using System.Threading.Tasks;

namespace SuperHeroRepository.Behavior
{
    public interface IHeroPersister
    {
        Task Create(Hero hero);
    }
}
