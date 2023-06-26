
using MS.Customer.Domain.DTO.Base;
using MS.Customer.Domain.Enum;
using System;

namespace MS.Customer.Domain
{
    public class CustomerDTO : BaseDTO
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public Generous Generous { get; set; }

        //public AddressDTO Address { get; set; }

        public CustomerDTO() { }

        public CustomerDTO(
            string name,
            string lastName,
            string email,
            string password,
            string phone,
            string cpf,
            Generous generous
            //AddressDTO address
            )
        {
            Name = name;
            LastName = lastName;
            Email = email;
            Password = password;
            Phone = phone;
            Cpf = cpf;
            Generous = generous;
            //Address = address;
        }
    }
}