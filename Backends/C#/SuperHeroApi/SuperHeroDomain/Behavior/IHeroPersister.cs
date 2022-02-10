using SuperHeroDomain.CustomModel;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHeroDomain.Behavior
{
    public interface IHeroPersister
    {
        Task<int> CreateHero(Guid publicId, CompleteHero completeHero, CancellationToken cancellationToken);
    }
}
