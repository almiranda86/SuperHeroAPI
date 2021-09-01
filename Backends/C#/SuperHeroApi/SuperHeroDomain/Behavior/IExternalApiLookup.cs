using SuperHeroDomain.CustomModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IExternalApiLookup
    {
        Task<CompleteHero> GetCompleteHeroById(int heroId);
    }
}
