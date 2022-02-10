using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroRepository.Persister.SQL
{
    public static class PersisterSQLQueries
    {
        public static string CreateCompleteHero()
        {
            return @"INSERT INTO complete_hero(""PUBLIC_ID"", ""HERO"") VALUES(@PUBLIC_ID,  CAST(@COMPLETE_HERO AS json));";
        }
    }
}
