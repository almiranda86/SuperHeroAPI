namespace SuperHeroRepository.Behavior
{
    public interface IDatabaseConfiguration
    {
        string DatabaseName { get; set; }
        string DatabaseServer { get; set; }
        string DatabaseUserId { get; set; }
        string DatabasePassword { get; set; }
        string DatabaseHost { get; set; }
        string DatabasePort { get; set; }

    }
}
