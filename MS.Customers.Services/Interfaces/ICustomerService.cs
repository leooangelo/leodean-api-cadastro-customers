using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.DTO.Customer;
using MS.Customer.Domain.Entities;
using MS.Customer.Domain.Paging;
using MS.Customer.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Services.Interfaces
{
    public interface ICustomerService
    {
        //Task<IList<ResponseCustomerDTO>> GetAsync();
        Task<ResponseCustomerDTO> GetByIdAsync(Guid customerId);
        Task<ResponseCustomerDTO> CreateAsync(CustomerDTO customerDTO);
        Task<ResponseCustomerDTO> UpdateCustomerAsync(Guid customerId, CustomerUpdateDTO customerDTO);

        Task ActiveCustomer(Guid customerId, CustomerActiveDeactiveViewModel customerActiveDeactiveViewModel);
        Task<Customers> GetByEmailAsync(string email);
        Task<Customers> GetByPhoneAnsync(string phone);
        Task<ResponsePaging<ResponseCustomerDTO>> GetAsyncPage(PagingFiltersBase pagingFiltersBase);
        Task UpdateCustomerEmailAsync(Guid customerId, CustomerUpdateEmailViewMoedel customerUpdateEmailViewMoedel);
        Task UpdateCustomerPassword(Guid customerId, CustomerUpdatePasswordViewModel customerUpdatePasswordViewModel);
    }
}
