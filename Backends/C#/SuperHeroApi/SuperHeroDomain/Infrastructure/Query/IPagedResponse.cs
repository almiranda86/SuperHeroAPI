using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Infrastructure.Query
{
    public interface IPagedResponse
    {
        /// <summary>
        /// Indicates the current page number
        /// </summary>
        int? CurrentPage { get; }

        /// <summary>
        /// Indicates how many pages are available
        /// </summary>
        int? PageCount { get; }

        /// <summary>
        /// Number of items returned per page
        /// </summary>
        int? PageSize { get; }

        /// <summary>
        /// Number of all items available
        /// </summary>
        int? TotalItems { get; }
    }
}
