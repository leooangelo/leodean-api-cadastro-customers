using Google;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MS.Customer.API.Token;
using MS.Customer.Config;
using MS.Customer.Domain.Middlewares;
using MS.Customer.Helpers;
using MS.Customer.Infra;
using MS.Customer.Infra.Context;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers()
    .AddNewtonsoftJson(j =>
    {
        j.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        j.SerializerSettings.Formatting = Formatting.Indented;
        j.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

builder.Services.AddHttpContextAccessor();

//builder.Services.AddDbContext<CustomerContext>(options =>
//{
//    options.UseSqlServer(configuration.GetConnectionString("CustomerContext"));

//    options.EnableSensitiveDataLogging();
//},
//    ServiceLifetime.Transient);


builder.Services.AddDbContext<CustomerContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("CustomerContext")),
    ServiceLifetime.Transient);

builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();

builder.Services.AddAsymmetricAuthentication(configuration);

builder.Services.AddAutoMapperConfiguration();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

//builder.Services.AddFluentEmail("no_reply@develine.com.br")
//       .AddRazorRenderer()
//       .AddSmtpSender("smtp.gmail.com", 587, "@develine.com.br", "D3!*(>)f0");



//builder.Services.AddMongoDb(applicationSettings.Mongo);

DependencyInjector.RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();