using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroRepository.Behavior
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
