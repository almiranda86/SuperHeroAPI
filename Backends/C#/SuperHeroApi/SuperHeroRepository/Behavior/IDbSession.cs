using System;
using System.Data;

namespace SuperHeroRepository.Behavior
{
    public interface IDbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public IDatabaseConfiguration DatabaseConfiguration { get; set; }
    }
}
