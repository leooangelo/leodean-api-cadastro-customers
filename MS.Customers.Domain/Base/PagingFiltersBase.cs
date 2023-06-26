using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Domain.Base
{
    public class PagingFiltersBase
    {

        public int page { get; set; }

        public int page_size { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
