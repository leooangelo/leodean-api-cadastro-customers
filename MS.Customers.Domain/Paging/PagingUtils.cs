using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Paging
{
    public class PagingUtils
    {
        public static ResponsePaging<T> Paging<T>(IQueryable<T> query, int page, int pageSize) where T : class
        {
            var response = new ResponsePaging<T>();
            var pagination = new PagingModel();

            pagination.current_page = page;
            pagination.row_count = query.Count();
            pagination.page_size= pageSize;
            response.pagination = pagination;

            var pageCount = (double)pagination.row_count / pageSize;
            pagination.page_count = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            response.data = query.Skip(skip).Take(pageSize).Distinct().ToList();
            return response;
        }
    }
}
