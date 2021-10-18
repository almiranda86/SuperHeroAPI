using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Infrastructure.Query
{
    public interface IPagedRequest
    {
        string SortOrder { get; set; }

        string Filter { get; set; }

        string SearchString { get; set; }

        int? Page { get; set; }

        int? PageSize { get; set; }
    }
}
