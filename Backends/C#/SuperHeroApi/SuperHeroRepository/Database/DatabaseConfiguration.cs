using SuperHeroRepository.Behavior;

namespace SuperHeroRepository.Database
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string DatabaseName { get; set; }
        public string DatabaseServer { get; set; }
        public string DatabaseUserId { get; set; }
        public string DatabasePassword { get; set; }
        public string DatabaseHost { get; set; }
        public string DatabasePort { get; set; }
    }
}
