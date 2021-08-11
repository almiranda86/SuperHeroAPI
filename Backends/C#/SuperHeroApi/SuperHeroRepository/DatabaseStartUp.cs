
using Dapper;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using System.Data.SQLite;
using System.Linq;

namespace SuperHeroRepository
{
    internal class DatabaseStartUp : IDatabaseStartUp
    {
        private readonly DatabaseConfiguration _databaseConfiguration;

        public DatabaseStartUp(DatabaseConfiguration databaseConfiguration)
        {
            _databaseConfiguration = databaseConfiguration;
        }

        public void Setup()
        {
            using var connection = new SQLiteConnection(_databaseConfiguration.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Hero';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Product")
                return;

            connection.Execute("Create Table Hero (" +
                "API_ID INTEGER NOT NULL," +
                "Name VARCHAR(1000) NULL);");
        }
    }
}
