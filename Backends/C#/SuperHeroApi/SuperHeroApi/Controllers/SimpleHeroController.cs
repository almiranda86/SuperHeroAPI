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
    public class SimpleHeroController : ControllerBase
    {
        [HttpGet()]
        [AllowAnonymous]
        public Task<IActionResult> ListAllHeroes(CancellationToken cancellationToken = default)
        {
            ListAllHeroesRequest request = new ListAllHeroesRequest();

            return this.HandleQueryRequest<ListAllHeroesRequest, ListAllHeroesResponse>(request, cancellationToken);
        }
    }
}