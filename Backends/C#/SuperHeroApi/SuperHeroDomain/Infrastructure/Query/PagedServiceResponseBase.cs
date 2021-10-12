using SuperHeroCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Infrastructure.Query
{
    public class PagedServiceResponseBase : ServiceResponse, IPagedResponse
    {
        public int? CurrentPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public int? TotalItems { get; set; }

        public static T FromIPagedResponse<T>(IPagedResponse paged)
            where T : PagedServiceResponseBase, new()
        {
            return new T
            {
                CurrentPage = paged.CurrentPage,
                PageCount = paged.PageCount,
                PageSize = paged.PageSize,
                TotalItems = paged.TotalItems
            };
        }
    }
}
