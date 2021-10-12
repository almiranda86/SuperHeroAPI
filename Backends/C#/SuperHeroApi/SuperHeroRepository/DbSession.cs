using Npgsql;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using System;
using System.Data;
using System.Data.SqlClient;
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
            //Connection = new SqlConnection($"Server={DatabaseConfiguration.DatabaseServer};Database={DatabaseConfiguration.DatabaseName};User Id={DatabaseConfiguration.DatabaseUserId};Password={DatabaseConfiguration.DatabasePassword};");
            Connection = new NpgsqlConnection($"User ID={DatabaseConfiguration.DatabaseUserId};Password={DatabaseConfiguration.DatabasePassword};Host={DatabaseConfiguration.DatabaseHost};Port={DatabaseConfiguration.DatabasePort};Database={DatabaseConfiguration.DatabaseName};");
            Connection.Open();
        }
    }
}
