using MS.Customer.Domain.Base;
using MS.Customer.Domain.Enum;
using System;
using BC = BCrypt.Net.BCrypt;


namespace MS.Customer.Domain.Entities
{
    public class Customers : BaseEntity
    {
        // Empty constructor for EF
        public Customers() { }

        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
        public Generous Generous { get; set; }
        public bool IsActive { get; set; }

        public void HashPassword()
        {
            Password = BC.HashPassword(Password);
        }

        public void HashDocument()
        {
            Cpf = BC.HashPassword(Cpf);
        }

        public void SetCpf(string cpf)
        {
            Cpf = BC.HashPassword(cpf);
        }

        public void SetPassword(string password)
        {
            Password = BC.HashPassword(password);
        }

        public void SetEmail(string newEmail)
        {
            Email = newEmail;
        }

    }
}