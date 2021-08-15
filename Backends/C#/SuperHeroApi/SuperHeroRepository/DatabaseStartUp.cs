
using Dapper;
using SuperHeroRepository.Behavior;
using SuperHeroRepository.Database;
using System.Data.SQLite;
using System.Linq;

namespace SuperHeroRepository
{
    public class DatabaseStartUp : IDatabaseStartUp
    {
        private readonly IDbSession _dbSession;

        public DatabaseStartUp(IDbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public void Setup()
        {
            var table = _dbSession.Connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Hero';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Hero")
                return;

            _dbSession.Connection.Execute("Create Table Hero (" +
                "API_ID INTEGER NOT NULL," +
                "Name VARCHAR(1000) NULL);");
        }
    }
}
