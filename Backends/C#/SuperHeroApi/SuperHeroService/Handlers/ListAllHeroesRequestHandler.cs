using MediatR;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class ListAllHeroesRequestHandler : IRequestHandler<ListAllHeroesRequest, ListAllHeroesResponse>
    {
        private readonly IHeroLookup _heroLookup;
        public ListAllHeroesRequestHandler(IHeroLookup heroLookup)
        {
            _heroLookup = heroLookup;
        }

        public async Task<ListAllHeroesResponse> Handle(ListAllHeroesRequest request, CancellationToken cancellationToken)
        {
            var response = await _heroLookup.GetAll();

            ListAllHeroesResponse listAllHeroesResponse = new ListAllHeroesResponse();
            listAllHeroesResponse.Heroes = response;

            return listAllHeroesResponse;
        }
    }
}
