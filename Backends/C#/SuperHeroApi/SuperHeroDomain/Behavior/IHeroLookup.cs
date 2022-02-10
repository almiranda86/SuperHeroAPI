﻿using SuperHeroDomain.CustomModel;
using SuperHeroDomain.Infrastructure.Query;
using SuperHeroDomain.Model;
using SuperHeroDomain.Model.HeroMaster;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroLookup
    {
        Task<List<Hero>> GetAll();
        Task<int> GetCountHeroes();
        Task<Hero> GetHeroByPublicId(string publicHeroId);
        Task<QueryPagedResponse<Hero>> GetAllHeroesPaginated(IPagedRequest context);
        Task<FullHero> GetCompleteHero(string publicHeroId);
    }
}
