

using BlazorChat.Common.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace BlazorChat.Common.Infrastructure.Extensions
{
    public static class PagingExtensions
    {
        public static async Task<PageViewModel<T>> GetPaged<T>(this IQueryable<T> query, int currentPage,
            int pageSize) where T : class
        {
            var count = await query.CountAsync();
            Page paging = new Page(currentPage,pageSize,count);
            var data = await query.Skip(paging.Skip).Take(paging.PageSize).AsNoTracking().ToListAsync();
            var result = new PageViewModel<T>(data, paging);
            return result;
        }
    }
}
