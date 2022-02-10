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
using SuperHeroDomain.CommandModel;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        [HttpGet("list_all_heroes")]
        [AllowAnonymous]
        public Task<IActionResult> ListAllHeroes(CancellationToken cancellationToken = default)
        {
            ListAllHeroesRequest request = new ListAllHeroesRequest();

            return this.HandleQueryRequest<ListAllHeroesRequest, ListAllHeroesResponse>(request, cancellationToken);
        }

        [HttpGet("list_all_heroes_with_pagination")]
        [AllowAnonymous]
        public Task<IActionResult> ListAllHeroesPaginated([FromQuery] int? page, [FromQuery] int? pageSize, CancellationToken cancellationToken = default)
        {
            ListAllHeroesPaginatedRequest request = new ListAllHeroesPaginatedRequest();
            request.Page = page;
            request.PageSize = pageSize;

            return this.HandleQueryRequest<ListAllHeroesPaginatedRequest, ListAllHeroesPaginatedResponse>(request, cancellationToken);
        }


        [HttpPost("create_all_heroes")]
        [AllowAnonymous]
        public Task<IActionResult> CreateAllHeroes(CancellationToken cancellationToken = default)
        {
            CreateAllHeroesRequest request = new CreateAllHeroesRequest();

            return this.HandleQueryRequest<CreateAllHeroesRequest, CreateAllHeroesResponse>(request, cancellationToken);
        }
    }
}