using SuperHeroRepository.Behavior;

namespace SuperHeroRepository.Database
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string Name { get; set; }
    }
}
