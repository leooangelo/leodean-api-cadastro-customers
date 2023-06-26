using MS.Customer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Customer.Infra.Data.DataAccess.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customers> GetByIdAsync(Guid customerId);
        Task<Customers> GetByEmailAsync(string email);
        Task<Customers> GetByPhoneAsync(string phone);
        Task<IList<Customers>> GetAsync();
        Task<Customers> CreateAsync(Customers customer);
        Task<Customers> UpdateCustomerAsync(Customers customer);
        Task<Customers> UpdateActiveCustomerAsync(Customers customer);
        Task<Customers> UpdateCustomerEmailAsync(Customers customer);
        Task<string> GetPassword(string email);
        Task<Customers> SetPasswordAsync(Customers customer);
    }
}