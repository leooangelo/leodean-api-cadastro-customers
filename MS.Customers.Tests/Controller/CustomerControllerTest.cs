using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using MS.Customer.Controller;
using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.ViewModel;
using MS.Customer.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MS.Customer.Tests.Controller
{
    public class CustomerControllerTest
    {
        private Mock<IMapper> _mapperMock;
        private Mock<ICustomerService> _customerServiceMock;
        private Mock<IHttpContextAccessor> httpContextAccessor;
        private Mock<ILogger<CustomerController>> logMock;
        private CustomerController controller;

        public CustomerControllerTest()
        {
            _mapperMock = new Mock<IMapper>();
            _customerServiceMock = new Mock<ICustomerService>();
            httpContextAccessor = new Mock<IHttpContextAccessor>();
            logMock = new Mock<ILogger<CustomerController>>();
            controller = new CustomerController(_mapperMock.Object, _customerServiceMock.Object, logMock.Object, httpContextAccessor.Object);
        }

        [Fact]
        public void GetByIdAsync()
        {
            _customerServiceMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(CustomerTemplate.ResponseCustomerDTO());
            var response = controller.GetByIdAsync(new Guid("B0E657FB-3A21-495F-A4DA-3008F08292E5"));
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void GetAsyncPage()
        {
            _customerServiceMock.Setup(x => x.GetAsyncPage(It.IsAny<PagingFiltersBase>())).ReturnsAsync(CustomerTemplate.PagingFiltersBaseResonseCustomDTO());

            var response = controller.GetAsyncPage(new PagingFiltersBase() { Email = "leozncontato@gmail.com"});
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void PostAsync()
        {
            _mapperMock.Setup(x => x.Map<CustomerDTO>(It.IsAny<CustomerViewModel>())).Returns(CustomerTemplate.CustomerDTO);
            _customerServiceMock.Setup(x => x.CreateAsync(It.IsAny<CustomerDTO>())).ReturnsAsync(CustomerTemplate.ResponseCustomerDTO);
            var response = controller.PostAsync(CustomerTemplate.CustomerViewModel());
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void UpdateCustomerAsync()
        {
            _mapperMock.Setup(x => x.Map<CustomerDTO>(It.IsAny<CustomerUpdateViewModel>())).Returns(CustomerTemplate.CustomerDTO);
            _customerServiceMock.Setup(x => x.UpdateCustomerAsync(It.IsAny<Guid>(), It.IsAny<CustomerUpdateDTO>())).ReturnsAsync(CustomerTemplate.ResponseCustomerDTOUpdate);
            var response = controller.UpdateCustomerAsync(new Guid(),CustomerTemplate.CustomerUpdateViewModel());
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void UpdateCustomerEmailAsync()
        {
            _customerServiceMock.Setup(x => x.UpdateCustomerEmailAsync(It.IsAny<Guid>(), It.IsAny<CustomerUpdateEmailViewMoedel>())).Returns(Task.FromResult(CustomerTemplate.CustomerUpdateEmailViewMoedel));
            var response = controller.UpdateCustomerEmailAsync(new Guid(), CustomerTemplate.CustomerUpdateEmailViewMoedel());
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void UpdateCustomerPassword()
        {
            _customerServiceMock.Setup(x => x.UpdateCustomerPassword(It.IsAny<Guid>(), It.IsAny<CustomerUpdatePasswordViewModel>())).Returns(Task.FromResult(CustomerTemplate.CustomerUpdatePasswordViewModel));
            var response = controller.UpdateCustomerPassword(new Guid(), CustomerTemplate.CustomerUpdatePasswordViewModel());
            Assert.NotNull(response.Result);
        }

        [Fact]
        public void ActiveCustomer()
        {
            _customerServiceMock.Setup(x => x.ActiveCustomer(It.IsAny<Guid>(), It.IsAny<CustomerActiveDeactiveViewModel>())).Returns(Task.FromResult(CustomerTemplate.CustomerActiveDeactiveViewModel));
            var response = controller.ActiveCustomer(new Guid(), CustomerTemplate.CustomerActiveDeactiveViewModel());
            Assert.NotNull(response.Result);
        }
    }
}
