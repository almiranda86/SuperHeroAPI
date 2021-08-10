using SuperHeroRepository.HeroMaster;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeroRepository.Behavior
{
    public interface IHeroLookup
    {
        Task<IEnumerable<Hero>> GetAll();
    }
}
