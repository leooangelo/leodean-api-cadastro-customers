using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS.Customer.Controllers.Base;
using MS.Customer.Domain;
using MS.Customer.Domain.Base;
using MS.Customer.Domain.DTO;
using MS.Customer.Domain.ViewModel;
using MS.Customer.Domain.ViewModels;
using MS.Customer.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace MS.Customer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService,
            ILogger<CustomerController> log,
            IHttpContextAccessor httpContextAccessor
            ) : base(log, httpContextAccessor)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid customerId)
        {
            return CustomResponse(await _customerService.GetByIdAsync(customerId));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsyncPage([FromQuery] PagingFiltersBase pagingFiltersBase)
        {
            return CustomResponse(await _customerService.GetAsyncPage(pagingFiltersBase));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CustomerViewModel customerViewModel)
        {
            var customerDTO = _mapper.Map<CustomerDTO>(customerViewModel);
            var customer = await _customerService.CreateAsync(customerDTO);
            return Ok(new ResultViewModel("Usuário criado com sucesso!", customer));
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerAsync([FromRoute] Guid customerId, [FromBody] CustomerUpdateViewModel customerViewModel)
        {
            var customerDTO = _mapper.Map<CustomerUpdateDTO>(customerViewModel);
            var customer = await _customerService.UpdateCustomerAsync(customerId, customerDTO);
            return Ok(new ResultViewModel("Usuário atualizado com sucesso!"));
        }

        [HttpPut("{customerId}/customer_email")]
        public async Task<IActionResult> UpdateCustomerEmailAsync(Guid CustomerId, [FromBody] CustomerUpdateEmailViewMoedel customerUpdateEmailViewMoedel)
        {
            await _customerService.UpdateCustomerEmailAsync(CustomerId, customerUpdateEmailViewMoedel);
            return Ok(new ResultViewModel("E-mail alterado com sucesso!"));
        }

        [HttpPut("{customerId}/customer_password")]
        public async Task<IActionResult> UpdateCustomerPassword(Guid CustomerId, [FromBody] CustomerUpdatePasswordViewModel customerUpdatePasswordViewModel)
        {
            await _customerService.UpdateCustomerPassword(CustomerId, customerUpdatePasswordViewModel);
            return Ok(new ResultViewModel("Senha alterada com sucesso!"));
        }

        //Rota para associar customer a um endereço na base de customer

        [HttpPost("{customerId}/active_deactivate")]
        public async Task<IActionResult> ActiveCustomer([FromRoute] Guid customerId, [FromBody] CustomerActiveDeactiveViewModel customerActiveDeactiveViewModel)
        {
            await _customerService.ActiveCustomer(customerId, customerActiveDeactiveViewModel);

            var messageResponse = customerActiveDeactiveViewModel.IsActive.Equals(true) ? "Usuário ativado com sucesso!" : "Usuário desativado com sucesso!";
            return Ok(new ResultViewModel(messageResponse));
        }
    }
}
