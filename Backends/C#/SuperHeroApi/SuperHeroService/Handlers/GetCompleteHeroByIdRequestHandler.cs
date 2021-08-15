using MediatR;
using SuperHeroDomain.Behavior;
using SuperHeroDomain.QueryModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.Handlers
{
    public class GetCompleteHeroByIdRequestHandler : IRequestHandler<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>
    {
        private readonly IHeroLookup _heroLookup;
        public GetCompleteHeroByIdRequestHandler(IHeroLookup heroLookup)
        {
           
        }

        public Task<GetCompleteHeroByIdResult> Handle(GetCompleteHeroByIdRequest request, CancellationToken cancellationToken)
        {
           


            throw new NotImplementedException();
        }
    }
}
