using MediatR;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class ListAllHeroesPaginatedRequestHandler : IRequestHandler<ListAllHeroesPaginatedRequest, ListAllHeroesPaginatedResponse>
    {
        private readonly IHeroLookup _heroLookup;

        public ListAllHeroesPaginatedRequestHandler(IHeroLookup heroLookup)
        {
            _heroLookup = heroLookup;
        }

        public async Task<ListAllHeroesPaginatedResponse> Handle(ListAllHeroesPaginatedRequest request, CancellationToken cancellationToken)
        {
            var response = await _heroLookup.GetAllHeroesPaginated(request.Page, request.PageSize);

            ListAllHeroesPaginatedResponse listAllHeroesResponse = new ListAllHeroesPaginatedResponse();
            listAllHeroesResponse.Heroes = response;

            return listAllHeroesResponse;
        }
    }
}
