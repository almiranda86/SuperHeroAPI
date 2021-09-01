using SuperHeroCore;
using SuperHeroDomain.BaseModel;
using SuperHeroDomain.CustomModel;
using SuperHeroDomain.Model;

namespace SuperHeroDomain.QueryModel
{
    public class GetCompleteHeroByIdResult : ServiceResponse
    {
        public CompleteHero completeHero { get; set; }
    }
}
