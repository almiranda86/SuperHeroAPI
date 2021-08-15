using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using System;
using System.Data;
using System.Data.SQLite;

namespace SuperHeroRepository
{
    public sealed class DbSession : IDbSession
    {
        private Guid _id;

        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; set; }
        public IDatabaseConfiguration DatabaseConfiguration { get; set; }

        public void Dispose() => Connection?.Dispose();

        public DbSession(IDatabaseConfiguration databaseConfiguration)
        {
            DatabaseConfiguration = databaseConfiguration;
            _id = Guid.NewGuid();
            Connection = new SQLiteConnection(DatabaseConfiguration.Name);
            Connection.Open();
        }
    }
}
