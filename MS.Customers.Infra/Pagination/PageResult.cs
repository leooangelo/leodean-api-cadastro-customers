using System.Collections.Generic;

namespace MS.Customer.Pagination
{
    public class  PageResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PageResult()
        {
            Results = new List<T>();
        }
    }
}
