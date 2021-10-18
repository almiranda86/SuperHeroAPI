using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Infrastructure.Query
{
    public interface IPagedResponse<T> : IPagedResponse
        where T : class
    {
        /// <summary>
        /// Page items
        /// </summary>
        List<T> Items { get; }
    }
}
