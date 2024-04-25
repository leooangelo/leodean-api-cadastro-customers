using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Quartz;
using System;

namespace MS.Customer.Quartz
{
    public class QuartzJobSetup : IConfigureOptions<QuartzOptions>
    {

        private readonly IConfiguration _configuration;

        public QuartzJobSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(QuartzOptions options)
        {
            //var cron = _configuration["Tempo"];//Tempo que o quartz ira rodar

            var jobKey = JobKey.Create(nameof(QuartzCustomJob));
            options
                .AddJob<QuartzCustomJob>(JobBuilder => JobBuilder.WithIdentity(jobKey))
                .AddTrigger(trigger =>
                    trigger.ForJob(jobKey)
                    .WithSimpleSchedule(schedule =>
                        schedule.WithInterval(TimeSpan.FromMinutes(Double.Parse("1")).Add(TimeSpan.FromSeconds(Double.Parse("10")))).RepeatForever()));
        }
    }
}
