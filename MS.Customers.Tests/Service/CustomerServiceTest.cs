using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.DTO.Customer;
using MS.Customer.Domain.Entities;
using MS.Customer.Infra.Data.DataAccess.Interfaces;
using MS.Customer.Infra.DataAccess.Repositories;
using MS.Customer.Services;
using MS.Customer.Utils.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Tests.Service
{
    public class CustomerServiceTest
    {
        private CustomerService service;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ICustomerRepository> _customerRepository;
        private readonly Mock<IValidator> _validator;

        public CustomerServiceTest()
        {
            _mapper = new Mock<IMapper>();
            _customerRepository = new Mock<ICustomerRepository>();
            _validator = new Mock<IValidator>();
            service = new CustomerService(_mapper.Object, _customerRepository.Object, _validator.Object) ;
        }
        [Fact]
        public void GetAsyncPage()
        {
            _customerRepository.Setup(x => x.GetAsync()).ReturnsAsync(CustomerTemplate.ListCustomers) ;
            _mapper.Setup(x => x.Map<IList<ResponseCustomerDTO>>(It.IsAny<IList<Customers>>())).Returns(CustomerTemplate.IListObjectResponse());

            var response = service.GetAsyncPage(new PagingFiltersBase() { Email = "leozncontato@gmail.com", Phone= "11916691211" });
            Assert.NotNull(response.Result);

        }

        [Fact]
        public void GetAsyncPagePagination()
        {
            _customerRepository.Setup(x => x.GetAsync()).ReturnsAsync(CustomerTemplate.ListCustomers);
            _mapper.Setup(x => x.Map<IList<ResponseCustomerDTO>>(It.IsAny<IList<Customers>>())).Returns(CustomerTemplate.IListObjectResponse());

            var response = service.GetAsyncPage(new PagingFiltersBase() {page = 1, page_size = 1 });
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void GetByIdAsync()
        {
            _customerRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(CustomerTemplate.Customers);
            _mapper.Setup(x => x.Map<ResponseCustomerDTO>(It.IsAny<Customers>())).Returns(CustomerTemplate.ResponseCustomerDTO());

            var response = service.GetByIdAsync(new Guid());
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void CreateAsync()
        {
            _mapper.Setup(x => x.Map<Customers>(It.IsAny<CustomerDTO>())).Returns(CustomerTemplate.CustomersCreate);
            _validator.Setup(x => x.IsCpf(It.IsAny<string>())).Returns(true);
            _customerRepository.Setup(x => x.GetAsync()).ReturnsAsync(CustomerTemplate.ListCustomers2);
            _customerRepository.Setup(x => x.CreateAsync(It.IsAny<Customers>())).ReturnsAsync(CustomerTemplate.CustomersCreate);
            _mapper.Setup(x => x.Map<ResponseCustomerDTO>(It.IsAny<Customers>())).Returns(CustomerTemplate.ResponseCustomerDTOCreated);

            var response = service.CreateAsync(CustomerTemplate.CustomerDTOCreate());
            Assert.NotNull(response.Result);

        }

        [Fact]
        public void CreateAsyncExist()
        {
            _mapper.Setup(x => x.Map<Customers>(It.IsAny<CustomerDTO>())).Returns(CustomerTemplate.CustomersCreate);
            _customerRepository.Setup(x => x.GetByEmailAsync(It.IsAny<string>())).ReturnsAsync(CustomerTemplate.CustomersCreate);
            _customerRepository.Setup(x => x.CreateAsync(It.IsAny<Customers>())).ReturnsAsync(CustomerTemplate.CustomersCreate);
            _mapper.Setup(x => x.Map<ResponseCustomerDTO>(It.IsAny<Customers>())).Returns(CustomerTemplate.ResponseCustomerDTOCreated);

            Assert.ThrowsAsync<Exception>(() => service.CreateAsync(CustomerTemplate.CustomerDTOCreate()));

        }

        [Fact]
        public void UpdateCustomerAsync()
        {
            _mapper.Setup(x => x.Map<Customers>(It.IsAny<CustomerUpdateDTO>())).Returns(CustomerTemplate.CustomersUpdateMap);
            _customerRepository.Setup(x => x.UpdateCustomerAsync(It.IsAny<Customers>())).ReturnsAsync(CustomerTemplate.CustomersUpdate);
            _mapper.Setup(x => x.Map<ResponseCustomerDTO>(It.IsAny<Customers>())).Returns(CustomerTemplate.ResponseCustomerDTOUpdate);

            var response = service.UpdateCustomerAsync(new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5"), CustomerTemplate.CustomerUpdateDTO());

            Assert.NotNull(response.Result);

        }

        [Fact]
        public void UpdateCustomerAsyncExist()
        {
            _mapper.Setup(x => x.Map<Customers>(It.IsAny<CustomerUpdateDTO>())).Returns(CustomerTemplate.CustomersUpdateMap);
            _customerRepository.Setup(x => x.GetByPhoneAsync(It.IsAny<string>())).ReturnsAsync(CustomerTemplate.Customers);
            _customerRepository.Setup(x => x.CreateAsync(It.IsAny<Customers>())).ReturnsAsync(CustomerTemplate.CustomersCreate);

            Assert.ThrowsAsync<Exception>(() => service.UpdateCustomerAsync(new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5"), CustomerTemplate.CustomerUpdateDTOErro()));
        }

        [Fact]
        public void ActiveCustomer()
        {
            _customerRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(CustomerTemplate.Customers);
            _customerRepository.Setup(x => x.UpdateActiveCustomerAsync(It.IsAny<Customers>())).ReturnsAsync(CustomerTemplate.Customers);

            var response = service.ActiveCustomer(new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5"), CustomerTemplate.CustomerActiveDeactiveViewModel());
            Assert.NotNull(response);
        }
    }
}
