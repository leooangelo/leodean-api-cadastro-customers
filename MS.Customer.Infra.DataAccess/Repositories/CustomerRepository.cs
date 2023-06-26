using Microsoft.EntityFrameworkCore;
using MS.Customer.Domain.Entities;
using MS.Customer.Domain.Enum;
using MS.Customer.Infra.Context;
using MS.Customer.Infra.Data.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.Customer.Infra.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private CustomerContext _customerContext;

        public CustomerRepository(CustomerContext customerContext)
        {
            
            _customerContext = customerContext;
        }

        public async Task<Customers> GetByIdAsync(Guid customerId)
        {
            var customer = await _customerContext.Customer.FindAsync(customerId);
            return customer;
        }

        public async Task<Customers> GetByEmailAsync(string email)
        {
            var customer = await _customerContext.Customer.FirstOrDefaultAsync(x => x.Email == email);
            return customer;
        }

        public async Task<Customers> GetByPhoneAsync(string phone)
        {
            var customer = await _customerContext.Customer.FirstOrDefaultAsync(x => x.Phone == phone);
            return customer;
        }

        public async Task<IList<Customers>> GetAsync()
        {
            var customers = await _customerContext.Customer.ToListAsync();
            return customers;
        }

        public async Task<Customers> CreateAsync(Customers customer)
        {
            await _customerContext.Customer.AddAsync(customer);
            await _customerContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customers> UpdateCustomerAsync(Customers customer)
        {
            var entry = _customerContext.Entry(customer);

            entry.State = EntityState.Modified;
            //entry.Property(x => x.CustomerId).IsModified = false;
            entry.Property(x => x.Password).IsModified = false;
            entry.Property(x => x.Cpf).IsModified = false;
            entry.Property(x => x.IsActive).IsModified = false;
            entry.Property(x => x.Email).IsModified = false;


            await _customerContext.SaveChangesAsync();

            return customer;
        }


        public async Task<Customers> UpdateActiveCustomerAsync(Customers customer)
        {
            var entry = _customerContext.Entry(customer);

            entry.State = EntityState.Modified;
            entry.Property(x => x.Password).IsModified = false;
            entry.Property(x => x.Name).IsModified = false;
            entry.Property(x => x.LastName).IsModified = false;
            entry.Property(x => x.Phone).IsModified = false;
            entry.Property(x => x.Cpf).IsModified = false;
            entry.Property(x => x.Generous).IsModified=false;
            entry.Property(x => x.Email).IsModified = false;


        await _customerContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customers> UpdateCustomerEmailAsync(Customers customer)
        {
            var entry = _customerContext.Entry(customer);

            entry.State = EntityState.Unchanged;
            entry.Property(x => x.Email).IsModified = true;

            await _customerContext.SaveChangesAsync();

            return customer;
        }

        public async Task<string> GetPassword(string email)
        {
            return await _customerContext.Customer.Where(x => x.Email == email).Select(x => x.Password).FirstOrDefaultAsync();
        }

        public async Task<Customers> SetPasswordAsync(Customers customer)
        {
            var entry = _customerContext.Entry(customer);

            entry.State = EntityState.Unchanged;
            entry.Property(x => x.Password).IsModified = true;

            await _customerContext.SaveChangesAsync();

            return customer;
        }

        public async Task<IList<Customers>> GetAsyncPagination(int page, int itemsPerPage)
        {
            var customers = await _customerContext.Customer
                .OrderBy(x => x.Name).Skip((page - 1) * itemsPerPage)
                           .Take(itemsPerPage)
                           .ToListAsync();

            return customers;
        }

    }
}