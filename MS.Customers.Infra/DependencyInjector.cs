using MS.Customer.AsymmetricEncryption;
using MS.Customer.CrossCutting;
using MS.Customer.CrossCutting.Services;
using MS.Customer.Infra.AsymmetricEncryption;
using MS.Customer.Infra.Certificates;
using MS.Customer.Infra.Certificates.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using MS.Customer.Infra.Context;
using MS.Customer.Services.Interfaces;
using MS.Customer.Services;
using MS.Customer.Infra.Data.DataAccess.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using MS.Customer.Infra.DataAccess.Repositories;
using MS.Customer.Utils.Validator;

namespace MS.Customer.Infra
{
    public static class DependencyInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<CustomerContext>();

            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<JwtSecurityTokenHandler>();

            services.AddScoped<IDateTimeNowProvider, DateTimeNowProvider>();

            services.AddScoped<ISigningAudienceCertificate, SigningAudienceCertificate>();
            services.AddScoped<ISigningIssuerCertificate, SigningIssuerCertificate>();


            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IValidator, CPFValidator>();
        }
    }
}
