using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Paging
{
    public class ResponsePaging<T> where T : class
    {
        public List<T> data { get; set; }

        public PagingModel pagination { get; set; }
    }
}
