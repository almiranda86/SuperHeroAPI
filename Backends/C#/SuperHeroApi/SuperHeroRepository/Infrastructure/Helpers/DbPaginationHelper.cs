using System;
using System.Collections.Generic;
using System.Text;

namespace SuperHeroRepository.Infrastructure.Helpers
{
    public static class DbPaginationHelper
    {
        private const int DEFAULT_PAGE_SIZE = 10;

        internal static (int?, int?) GetPageIndexes(int? currentPage, int? pageSize = DEFAULT_PAGE_SIZE)
        {
            if (!currentPage.HasValue || currentPage.Value == 0)
                return (null, null);

            int auxPageSize = (pageSize.HasValue ? pageSize.Value : DEFAULT_PAGE_SIZE);
            int firstItem = ((currentPage.Value - 1) * auxPageSize) + 1;
            int lastItem = (firstItem + auxPageSize - 1);

            return (firstItem, lastItem);

        }
    }
}
