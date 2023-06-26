using AutoMapper;
using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.DTO.Customer;
using MS.Customer.Domain.Entities;
using MS.Customer.Domain.Paging;
using MS.Customer.Domain.ViewModel;
using MS.Customer.Infra.Data.DataAccess.Interfaces;
using MS.Customer.Services.Interfaces;
using MS.Customer.Utils.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace MS.Customer.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidator _validator;


        public CustomerService(IMapper mapper, ICustomerRepository customerRepository, IValidator validator )
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _validator = validator;
        }

        public async Task<ResponsePaging<ResponseCustomerDTO>> GetAsyncPage(PagingFiltersBase pagingFiltersBase)
        {

            var customersBase = await _customerRepository.GetAsync();
            var customerQuery = _mapper.Map<IList<ResponseCustomerDTO>>(customersBase).ToList().AsQueryable();

            #region Filtros
            if (!string.IsNullOrEmpty(pagingFiltersBase.Email))
                customerQuery = customerQuery.Where(c => c.Email == pagingFiltersBase.Email);

            if (!string.IsNullOrEmpty(pagingFiltersBase.Phone))
                customerQuery = customerQuery.Where(c => c.Phone == pagingFiltersBase.Phone);
            #endregion

            var responseCustomer = (from c in customerQuery.ToList() select c).ToList();

            if (pagingFiltersBase.page > 0 && pagingFiltersBase.page_size > 0)
            {
                var page = PagingUtils.Paging(responseCustomer.AsQueryable(), pagingFiltersBase.page, pagingFiltersBase.page_size);

                ResponsePaging<ResponseCustomerDTO> responsePaging = new ResponsePaging<ResponseCustomerDTO>();
                responsePaging.pagination = new PagingModel()
                {
                    page_count = page.pagination.page_count,
                    page_size = page.pagination.page_size,
                    current_page = page.pagination.current_page,
                    row_count = page.pagination.row_count
                };

                responsePaging.data = page.data;
                return responsePaging;
            }

            return new ResponsePaging<ResponseCustomerDTO>()
            {
                data = responseCustomer
            };

        }

        public async Task<ResponseCustomerDTO> GetByIdAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            return _mapper.Map<ResponseCustomerDTO>(customer);
        }

        public async Task<ResponseCustomerDTO> CreateAsync(CustomerDTO customerDTO)
        {
            var customerToAdd = _mapper.Map<Customers>(customerDTO);
            customerValid(customerToAdd);
            customerToAddExist(customerToAdd.Email, customerToAdd.Cpf, customerToAdd.Phone);

            customerToAdd.HashPassword();
            customerToAdd.HashDocument();

            var customer = await _customerRepository.CreateAsync(customerToAdd);

            var responseCustomer = _mapper.Map<ResponseCustomerDTO>(customer);

            return responseCustomer;
        }

        public async Task<ResponseCustomerDTO> UpdateCustomerAsync(Guid customerId, CustomerUpdateDTO customerDTO)
        {

            var customerPhoneUpdateExistResponse = customerPhoneUpdateExist(customerDTO.Phone, customerId);

            if (customerPhoneUpdateExistResponse == true)
                throw new Exception("Erro, telefone ou celular ja cadastrado");

            var customerToUpdate = _mapper.Map<Customers>(customerDTO); 
            customerToUpdate.CustomerId = customerId;

            var customer = await _customerRepository.UpdateCustomerAsync(customerToUpdate);
            return _mapper.Map<ResponseCustomerDTO>(customer);
        }

        public async Task ActiveCustomer(Guid customerId, CustomerActiveDeactiveViewModel customerActiveDeactiveViewModel)
        {

            var customer = await _customerRepository.GetByIdAsync(customerId);
            customer.IsActive = customerActiveDeactiveViewModel.IsActive;

            await _customerRepository.UpdateActiveCustomerAsync(customer);

        }

        public async Task UpdateCustomerEmailAsync(Guid customerId, CustomerUpdateEmailViewMoedel customerUpdateEmailViewMoedel)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new Exception("Erro, customer não existe!");

            if (!BC.Verify(customerUpdateEmailViewMoedel.Password, customer.Password))
                throw new Exception("Erro, Senha inválida.");

            if (!customerUpdateEmailViewMoedel.NewEmailConfirmed.Equals(customerUpdateEmailViewMoedel.NewEmail))
                throw new Exception("Erro, e-mail informado não é compativel com a confirmação de e-mail!");
           
            if(customerUpdateEmailViewMoedel.NewEmailConfirmed.Equals(customer.Email))
                throw new Exception("Erro, novo e-mail não pode ser igual ao e-mail atual!");
            customer.SetEmail(customerUpdateEmailViewMoedel.NewEmailConfirmed);

            await _customerRepository.UpdateCustomerEmailAsync(customer);

        }

        public async Task UpdateCustomerPassword(Guid customerId, CustomerUpdatePasswordViewModel customerUpdatePasswordViewModel)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (!BC.Verify(customerUpdatePasswordViewModel.OldPassword, customer.Password))
                throw new Exception("Erro, Senha inválida!");

            if (!customerUpdatePasswordViewModel.NewPasswordConfirmed.Equals(customerUpdatePasswordViewModel.NewPassword))
                throw new Exception("Erro, nova senha inválida, tente novamente!");

            customer.SetPassword(customerUpdatePasswordViewModel.NewPasswordConfirmed);

            await _customerRepository.SetPasswordAsync(customer);
        }

        public async Task<Customers> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            return customer;
        }

        public async Task<Customers> GetByPhoneAnsync(string phone)
        {
            var customer = await _customerRepository.GetByPhoneAsync(phone);
            return customer;
        }

        private Boolean customerPhoneUpdateExist(string phone, Guid customerId)
        {
            Customers res = GetByPhoneAnsync(phone).Result;

            if (res == null)
                return false;

            if (customerId == res.CustomerId)
                return false;

            return true;
        }


        private void customerValid(Customers customerToAdd)
        {
            var cpfValid = _validator.IsCpf(customerToAdd.Cpf);

            if(cpfValid == false)
                throw new Exception("Erro, CPF inválido!");

        }


        private void customerToAddExist(string email, string cpf, string phone)
        {
            var customers = _customerRepository.GetAsync().Result;

            foreach(var c in customers)
            {
               if(BC.Verify(cpf, c.Cpf))
                  throw new Exception("Erro, CPF ja cadastrado.");
               
                if(c.Email.Equals(email))
                   throw new Exception("Erro, email ja cadastrado.");

                if (c.Phone.Equals(phone))
                    throw new Exception("Erro, telefone ou celular ja cadastrado.");
            }
        }
    }
}
