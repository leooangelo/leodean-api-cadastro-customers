using MS.Customer.Domain.DTO.Base;
using MS.Customer.Domain.Enum;
using System;
using System.Collections.Generic;

namespace MS.Customer.Domain.DTO.Customer
{
    public class ResponseCustomerDTO : ResponseBaseDTO
    {
        public Guid CustomerId { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public Generous Generous { get; set; }
        public bool IsActive { get; set; }

        //public IList<ResponseAddressDTO> Address { get; set; }

        public ResponseCustomerDTO() { }

    }
}