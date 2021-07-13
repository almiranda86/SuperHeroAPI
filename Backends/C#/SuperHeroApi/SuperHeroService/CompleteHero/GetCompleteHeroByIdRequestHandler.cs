using MediatR;
using SuperHeroDomain.QueryModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroService.CompleteHero
{
    public class GetCompleteHeroByIdRequestHandler : IRequestHandler<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>
    {
        public Task<GetCompleteHeroByIdResult> Handle(GetCompleteHeroByIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
