using MediatR;
using SuperHeroDomain.CustomModel;
using System;
using System.Collections.Generic;

namespace SuperHeroDomain.CommandModel
{
    public class CreateAllHeroesRequest : IRequest<CreateAllHeroesResponse>
    {
        public Dictionary<Guid, CompleteHero> AllHeroes { get; set; }

        public CreateAllHeroesRequest()
        {
            AllHeroes = new Dictionary<Guid, CompleteHero>();
        }
    }
}
