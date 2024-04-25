using MS.Customer.Domain.Base;
using MS.Customer.Services.Interfaces;
using Quartz;
using System;
using System.Threading.Tasks;

namespace MS.Customer.Quartz
{
    [DisallowConcurrentExecution]
    public class QuartzCustomJob :IJob
    {
        private ICustomerService _customerService;

        public QuartzCustomJob(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task Execute(IJobExecutionContext jobExecutionContext)
        {
            Console.WriteLine("Rodando Quartz : " + DateTime.Now.ToString());
            var taskCustomer = _customerService.GetAsyncPage(new PagingFiltersBase());
            await Task.WhenAll(taskCustomer);
        }
    }
}
