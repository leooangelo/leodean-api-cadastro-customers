using MS.Customer.Domain.Enum;
using System;

namespace MS.Customer.Domain.DTO
{
    public class CustomerUpdateDTO
    {   
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public Generous Generous { get; set; }
    }
}