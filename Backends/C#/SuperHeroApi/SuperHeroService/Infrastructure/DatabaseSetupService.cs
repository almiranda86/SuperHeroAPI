using SuperHeroDomain.Behavior;
using SuperHeroDomain.HeroMaster;
using SuperHeroService.Infrastructure.Behavior;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuperHeroService.Infrastructure
{
    public class DatabaseSetupService : IDatabaseSetupService
    {
        private readonly IHeroPersister _heroPersister;
        private readonly IHeroLookup _heroLookup;

        public DatabaseSetupService(IHeroPersister heroPersister,
                                    IHeroLookup heroLookup)
        {
            _heroPersister = heroPersister;
            _heroLookup = heroLookup;
        }

        public async Task FillDatabase()
        {
            var result = await _heroLookup.GetCountHeroes();

            if (result == 0 || result > 731) 
            {
                List<Hero> heroes = new List<Hero>();

                string fileContent = Properties.Resources.heroes;

                fileContent = fileContent.Replace("\r", "");

                var splitedContent = fileContent.Split('\n');

                foreach (string lineContent in splitedContent)
                {
                    if (string.IsNullOrWhiteSpace(lineContent))
                        break;
                    var lineSplitedContent = lineContent.Split('\t');

                    var hero = new Hero()
                    {
                        API_ID = Convert.ToInt32(lineSplitedContent[0]),
                        NAME = lineSplitedContent[1],
                        PUBLIC_ID = Guid.NewGuid().ToString()
                    };

                    heroes.Add(hero);
                }

                InsertIntoDatabase(heroes);
            }
        }

        private void InsertIntoDatabase(List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                _heroPersister.Create(hero);
            }
        }
    }
}
