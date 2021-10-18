using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperHeroApi.Infrastructure;
using SuperHeroDomain.QueryModel;
using System.Threading;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompleteHeroController : ControllerBase
    {

        [HttpGet("{hero_publicId}")]
        [AllowAnonymous]
        public  Task<IActionResult> GetCompleteHero([FromRoute] string hero_publicId, CancellationToken cancellationToken = default)
        {

            GetCompleteHeroByIdRequest request = new GetCompleteHeroByIdRequest()
            {
                PublicHeroId = hero_publicId
            };

            return this.HandleQueryRequest<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>(request, cancellationToken);
        }
    }
}