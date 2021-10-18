using SuperHeroDomain.Infrastructure.Query;

namespace SuperHeroDomain.Infrastructure.Extensions
{
    public static class PagedResponseExtensions
    {
        public static T FromIPagedResponse<T>(this IPagedResponse ctx)
            where T : PagedServiceResponseBase, new()
        {
            return PagedServiceResponseBase.FromIPagedResponse<T>(ctx);
        }
    }
}
