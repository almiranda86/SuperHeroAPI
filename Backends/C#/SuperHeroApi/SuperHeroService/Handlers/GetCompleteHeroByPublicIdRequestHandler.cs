using MediatR;
using Microsoft.Extensions.Configuration;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class GetCompleteHeroByPublicIdRequestHandler : IRequestHandler<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly IExternalApiLookup _externalApiLookup;
        public GetCompleteHeroByPublicIdRequestHandler(IHeroLookup heroLookup,
                                                       IExternalApiLookup externalApiLookup,
                                                       IConfiguration configuration)
        {
            _heroLookup = heroLookup;
            _externalApiLookup = externalApiLookup;
        }

        public async Task<GetCompleteHeroByIdResult> Handle(GetCompleteHeroByIdRequest request, CancellationToken cancellationToken)
        {
            GetCompleteHeroByIdResult result = new GetCompleteHeroByIdResult();

            try
            {
                var responseHero = await _heroLookup.GetHeroByPublicId(request.PublicHeroId);

                var responseCompleteHero = await _externalApiLookup.GetCompleteHeroById(responseHero.API_ID);

                responseCompleteHero.Id = request.PublicHeroId;

                result.completeHero = responseCompleteHero;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}
