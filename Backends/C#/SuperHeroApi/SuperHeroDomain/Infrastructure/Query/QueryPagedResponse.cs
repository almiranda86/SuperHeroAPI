using SuperHeroDomain.Model.HeroMaster;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroDomain.Infrastructure.Query
{
    public class QueryPagedResponse<T> : IPagedResponse<T>
        where T : class
    {
        private int? _pageSize;
        private int? _totalItems;

        public int? CurrentPage { get; set; }

        public int? PageCount { get; private set; }

        public int? PageSize { get => _pageSize; set { _pageSize = value; SetPageCount(); } }

        public int? TotalItems { get => _totalItems; set { _totalItems = value; SetPageCount(); } }

        public List<T> Items { get; set; }

        public QueryPagedResponse()
            : this(null, null, null, new List<T>())
        {
        }

        public QueryPagedResponse(int? currentPage, int? pageSize, int? totalItems, List<T> items)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalItems = totalItems;
            Items = items;

            SetPageCount();
        }

        void SetPageCount()
        {
            int pageCount = 0;
            if (PageSize.HasValue && PageSize > 0)
            {
                int totalItems = (TotalItems ?? 0);
                pageCount = (totalItems / PageSize.Value);

                if (totalItems % PageSize != 0)
                {
                    pageCount++;
                }
            }

            PageCount = pageCount;
        }

        public static implicit operator QueryPagedResponse<T>(QueryPagedResponse<Hero> v)
        {
            throw new NotImplementedException();
        }
    }
}
