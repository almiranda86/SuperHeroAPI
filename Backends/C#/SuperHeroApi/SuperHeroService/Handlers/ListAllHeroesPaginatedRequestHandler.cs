using MediatR;
using SuperHeroCore.Logs.Behavior;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.Infrastructure.Extensions;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;
using SuperHeroCore.Logs.Constants;

namespace SuperHeroService.Handlers
{
    public class ListAllHeroesPaginatedRequestHandler : IRequestHandler<ListAllHeroesPaginatedRequest, ListAllHeroesPaginatedResponse>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly ILogManager _logManager;


        public ListAllHeroesPaginatedRequestHandler(IHeroLookup heroLookup, ILogManager logManager)
        {
            _heroLookup = heroLookup;
            _logManager = logManager;
        }

        public async Task<ListAllHeroesPaginatedResponse> Handle(ListAllHeroesPaginatedRequest request, CancellationToken cancellationToken)
        {
            _logManager.AddTrace(LogTexts.BegginingExecution(nameof(ListAllHeroesPaginatedRequestHandler), DateTime.Now));

            var response = new ListAllHeroesPaginatedResponse();

            var pagedResponse = await _heroLookup.GetAllHeroesPaginated(request);

            response = pagedResponse.FromIPagedResponse<ListAllHeroesPaginatedResponse>();
            response.Heroes = pagedResponse.Items;

            _logManager.AddTrace(LogTexts.EndingExecution(nameof(ListAllHeroesPaginatedRequestHandler), DateTime.Now));

            return response;
        }
    }
}
