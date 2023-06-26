using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Paging
{
    public class PagingModel
    {
        public int current_page { get; set; }

        public int page_count { get; set; }

        public int page_size { get; set; }

        public int row_count { get; set; }
    }
}
