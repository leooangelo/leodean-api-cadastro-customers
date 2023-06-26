using MS.Customer.Domain.Enum;
using MS.Customer.Infra.Certificates;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;

namespace MS.Customer.Helpers
{
    public static class AuthenticationHelper
    {
        public static IServiceCollection AddAsymmetricAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var issuerSigningCertificate = new SigningIssuerCertificate(configuration);

            //RsaSecurityKey issuerSigningKeyUser = issuerSigningCertificate.GetIssuerSigningKey(JwtCertified.User);
            RsaSecurityKey issuerSigningKeyCustomer = issuerSigningCertificate.GetIssuerSigningKey(JwtCertified.Customer);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = issuerSigningKeyCustomer,
                        LifetimeValidator = LifetimeValidator,
                        ValidateLifetime = true,
                        RequireExpirationTime = false,
                    };
                });
            //.AddJwtBearer("JwtCustomer", options =>
            //{
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateAudience = false,
            //        ValidateIssuer = false,
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = issuerSigningKeyCustomer,
            //        LifetimeValidator = LifetimeValidator
            //    };
            //});

            //services
            //    .AddAuthorization(options =>
            //    {
            //        //options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            //        //    .RequireAuthenticatedUser()
            //        //    .AddAuthenticationSchemes("JwtUser", "JwtCustomer")
            //        //    .Build();

            //        options.AddPolicy("JwtUser", new AuthorizationPolicyBuilder()
            //            .RequireAuthenticatedUser()
            //            .AddAuthenticationSchemes("JwtUser")
            //            //.RequireClaim("role", "admin")
            //            .Build());

            //        options.AddPolicy("JwtCustomer", new AuthorizationPolicyBuilder()
            //            .RequireAuthenticatedUser()
            //            .AddAuthenticationSchemes("JwtCustomer")
            //            //.RequireClaim("role", "admin")
            //            .Build());
            //    });

            return services;
        }

        private static bool LifetimeValidator(DateTime? notBefore,
            DateTime? expires,
            SecurityToken securityToken,
            TokenValidationParameters validationParameters)
        {
            return expires.HasValue && expires > DateTime.UtcNow;
        }
    }
}
