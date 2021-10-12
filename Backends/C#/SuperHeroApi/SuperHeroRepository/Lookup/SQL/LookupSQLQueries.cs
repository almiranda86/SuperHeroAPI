using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroRepository.Lookup.SQL
{
    public static class LookupSQLQueries
    {
        public static string GetAll()
        {
            return @"SELECT id, public_id, api_id, name FROM hero;";
        }

        public static string GetCountHeroes()
        {
            return @"SELECT COUNT(PUBLIC_ID) FROM Hero;";
        }

        public static string GetHeroByPublicId()
        {
            return @"SELECT id, public_id, api_id, name FROM Hero WHERE PUBLIC_ID = @PUBLIC_ID;";
        }
    }
}
