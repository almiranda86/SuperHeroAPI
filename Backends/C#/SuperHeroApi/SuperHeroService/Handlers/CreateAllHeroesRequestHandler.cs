using MediatR;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.CommandModel;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class CreateAllHeroesRequestHandler : IRequestHandler<CreateAllHeroesRequest, CreateAllHeroesResponse>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly IExternalApiLookup _externalApiLookup;
        private readonly IHeroPersister _heroPersister;
        public CreateAllHeroesRequestHandler(IHeroLookup heroLookup,
                                             IExternalApiLookup externalApiLookup,
                                             IHeroPersister heroPersister)
        {
            _heroLookup = heroLookup;
            _externalApiLookup = externalApiLookup;
            _heroPersister = heroPersister;
        }

        public async Task<ListAllHeroesResponse> Handle(ListAllHeroesRequest request, CancellationToken cancellationToken)
        {
            var response = await _heroLookup.GetAll();

            ListAllHeroesResponse listAllHeroesResponse = new ListAllHeroesResponse();
            listAllHeroesResponse.Heroes = response;

            return listAllHeroesResponse;
        }

        public async Task<CreateAllHeroesResponse> Handle(CreateAllHeroesRequest request, CancellationToken cancellationToken)
        {
            CreateAllHeroesResponse allHeroesResponse = new CreateAllHeroesResponse();

            var response = await _heroLookup.GetAll();

            foreach (var hero in response)
            {
                var completeHero = await _externalApiLookup.GetCompleteHeroById(hero.API_ID);

                if (completeHero != null)
                {
                    request.AllHeroes.Add(hero.PUBLIC_ID, completeHero);
                }
            }

            foreach (var completeHero in request.AllHeroes)
            {
                var created = await _heroPersister.CreateHero(completeHero.Key, completeHero.Value, cancellationToken);
            }

            return allHeroesResponse;
        }
    }
}
