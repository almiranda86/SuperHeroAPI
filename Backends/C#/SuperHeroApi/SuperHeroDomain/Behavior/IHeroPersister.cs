using SuperHeroDomain.HeroMaster;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroPersister
    {
        Task Create(Hero hero);
    }
}
