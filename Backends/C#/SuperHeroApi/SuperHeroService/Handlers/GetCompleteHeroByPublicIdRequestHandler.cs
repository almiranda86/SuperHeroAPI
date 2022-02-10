using MediatR;
using Microsoft.Extensions.Configuration;
using SuperHeroCore.Extension;
using SuperHeroCore.Logs.Behavior;
using SuperHeroCore.Logs.Constants;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.CustomModel;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class GetCompleteHeroByPublicIdRequestHandler : IRequestHandler<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>
    {
        private readonly IHeroLookup _heroLookup;
        private readonly ILogManager _logManager;
        public GetCompleteHeroByPublicIdRequestHandler(IHeroLookup heroLookup,
                                                       ILogManager logManager)
        {
            _heroLookup = heroLookup;
            _logManager = logManager;
        }

        public async Task<GetCompleteHeroByIdResult> Handle(GetCompleteHeroByIdRequest request, CancellationToken cancellationToken)
        {
            GetCompleteHeroByIdResult result = new GetCompleteHeroByIdResult();

            try
            {
                var responseHero = await _heroLookup.GetCompleteHero(request.PublicHeroId);

                result.completeHero = responseHero.HERO.FromJson<CompleteHero>();
            }
            catch (Exception ex)
            {
                _logManager.AddError(SuperHeroCore.Enums.Issues.GetCompleteHeroByPublicIdRequestHandler_0001,
                                    LogTexts.ErrorWhenGettingCompleteHero(nameof(GetCompleteHeroByPublicIdRequestHandler.Handle), DateTime.Now, request.PublicHeroId, ex.Message));
            }

            return result;
        }
    }
}
