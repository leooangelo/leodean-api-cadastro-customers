using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MS.Customer.CrossCutting;
using MS.Customer.Domain.Enum;
using MS.Customer.Infra.AsymmetricEncryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MS.Customer.Domain.Entities;

namespace MS.Customer.API.Token
{
    public class TokenGenerator : ITokenGenerator
    {
        private readonly IConfiguration _configuration;
        private readonly ISigningAudienceCertificate _signingAudienceCertificate;
        private readonly IDateTimeNowProvider _dateTimeProvider;

        public TokenGenerator(
            IConfiguration configuration,
            ISigningAudienceCertificate signingAudienceCertificate,
            IDateTimeNowProvider dateTimeProvider
            )
        {
            _configuration = configuration;
            _signingAudienceCertificate = signingAudienceCertificate;
            _dateTimeProvider = dateTimeProvider;
        }

        public string GenerateToken(Customers customer, Guid establishmentId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(customer, establishmentId);
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        private SecurityTokenDescriptor GetTokenDescriptor(Customers customer, Guid establishmentId)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims(customer, establishmentId)),
                Expires = _dateTimeProvider.CurrentDateTime.AddMinutes(5),
                //Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["JwtCustomer:HoursToExpire"])),
                //SigningCredentials = _signingAudienceCertificate.GetAudienceSigningKey(JwtCertified.Customer)
                SigningCredentials = _signingAudienceCertificate.GetAudienceSigningKey(JwtCertified.User)
            };

            return tokenDescriptor;
        }

        private IEnumerable<Claim> Claims(Customers customer, Guid establishmentId)
        {
            var claims = new List<Claim> {
                new Claim("EstablishmentID", establishmentId.ToString()),
                new Claim("CustomerUid", customer.CustomerId.ToString())
            };

            claims.Add(new Claim(ClaimTypes.Role, "Customer"));

            return claims;
        }
    }
}
