using SuperHeroCore;
using System;

namespace SuperHeroDomain.Infrastructure.Query
{
    public class QueryPagedRequest<TResult> : QueryRequest<TResult>, IPagedRequest
    {
        public int? PageSize { get; set; }
    }
}
