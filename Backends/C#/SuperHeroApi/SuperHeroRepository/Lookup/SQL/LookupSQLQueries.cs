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
            return @"SELECT id, public_id, api_id, name FROM Hero WHERE PUBLIC_ID::text = @PUBLIC_ID;";
        }

        public static string GetAllHeroesPaginated()
        {
            return @" WITH CA AS(
	                            SELECT 
		                            ROW_NUMBER() OVER (ORDER BY NAME ASC) AS LINE_NUMBER,
		                            COUNT(*) OVER () TOTAL_ROWS,
		                            h.ID, 
		                            h.PUBLIC_ID, 
		                            h.API_ID,
		                            h.NAME
	                            FROM hero h
                            ORDER BY h.ID)

                    SELECT * FROM CA
                     WHERE(@PARAM_FIRST_ROW is null OR @PARAM_FIRST_ROW <= CA.LINE_NUMBER)
                       AND(@PARAM_LAST_ROW is null	OR @PARAM_LAST_ROW >= CA.LINE_NUMBER);";
        }

        public static string GetCompleteHeroByPublicId()
        {
            return @"SELECT ""PUBLIC_ID"", ""HERO"" FROM Complete_Hero WHERE ""PUBLIC_ID""::text = @PUBLIC_ID;";
        }
    }
}
