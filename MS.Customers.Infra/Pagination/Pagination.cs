using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Customer.Pagination
{
    public static class Pagination
    {
        public static PageResult<T> PagedResult<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PageResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = query.AsNoTracking().Count();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        public static async Task<PageResult<T>> PagedResultAsync<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PageResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;

            result.RowCount = await query.AsNoTracking().CountAsync();

            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = await query.Skip(skip).Take(pageSize).ToListAsync();

            return result;
        }
    }
}
