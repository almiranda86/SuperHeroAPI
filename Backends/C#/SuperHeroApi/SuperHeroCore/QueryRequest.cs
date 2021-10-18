using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroCore
{
    public class QueryRequest<TResult>: IRequest<TResult>
    {
        public string SortOrder { get; set; }
        public string Filter { get; set; }
        public string SearchString { get; set; }
        public int? Page { get; set; }
    }
}
