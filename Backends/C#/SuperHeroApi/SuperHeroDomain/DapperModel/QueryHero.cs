using SuperHeroDomain.DapperModel.Base;
using SuperHeroDomain.Model.HeroMaster;

namespace SuperHeroDomain.DapperModel
{
    public class QueryHero : Hero, IPaginatedModel
    {
        public int LINE_NUMBER { get; set; }
        public int TOTAL_ROWS { get; set; }
    }
}
