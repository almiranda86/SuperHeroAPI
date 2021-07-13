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

        [HttpGet("{heroId}")]
        [AllowAnonymous]
        public  Task<IActionResult> GetCompleteHero([FromRoute] string heroId, CancellationToken cancellationToken = default)
        {

            GetCompleteHeroByIdRequest request = new GetCompleteHeroByIdRequest()
            {
                HeroId = heroId
            };

            return this.HandleQueryRequest<GetCompleteHeroByIdRequest, GetCompleteHeroByIdResult>(request, cancellationToken);
        }
    }
}