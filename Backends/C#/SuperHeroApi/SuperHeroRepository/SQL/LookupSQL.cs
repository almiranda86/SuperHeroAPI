using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroRepository.SQL
{
    public static partial class LookupSQL
    {
        public static string SelectAllHeroes()
        {
            return @"SELECT PUBLIC_ID, NAME FROM Hero;";
        }

        public static string SelectCountTotalHeroes()
        {
            return @"SELECT COUNT(PUBLIC_ID) FROM Hero;";
        }

        public static string SelectHeroById()
        {
            return @"SELECT PUBLIC_ID, NAME, API_ID FROM Hero WHERE PUBLIC_ID = @PUBLIC_ID;";
        }
    }
}
