using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.QueryModel
{
    public class GetCompleteHeroByIdRequest : IRequest<GetCompleteHeroByIdResult>
    {
        public string PublicHeroId { get; set; }
    }
}
