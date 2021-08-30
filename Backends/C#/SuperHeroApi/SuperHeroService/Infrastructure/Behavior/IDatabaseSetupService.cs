using System.Threading.Tasks;

namespace SuperHeroService.Infrastructure.Behavior
{
    public interface IDatabaseSetupService
    {
        Task FillDatabase();
    }
}
