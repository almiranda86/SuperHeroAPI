using SuperHeroRepository.Database;
using System;
using System.Data;
using System.Data.SQLite;

namespace SuperHeroRepository
{
    internal sealed class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        private readonly DatabaseConfiguration _databaseConfiguration;

        public DbSession(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
            _id = Guid.NewGuid();
            Connection = new SQLiteConnection(_databaseConfiguration.Name);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
