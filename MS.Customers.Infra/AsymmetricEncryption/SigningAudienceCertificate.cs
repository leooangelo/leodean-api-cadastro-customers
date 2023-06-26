using System;
using System.IO;
using System.Security.Cryptography;
using MS.Customer.Domain.Enum;
using MS.Customer.Infra.AsymmetricEncryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MS.Customer.AsymmetricEncryption
{
    public class SigningAudienceCertificate : ISigningAudienceCertificate, IDisposable
    {
        private readonly RSA rsa;
        private readonly IConfiguration _configuration;

        public SigningAudienceCertificate(IConfiguration configuration)
        {
            rsa = RSA.Create();
            _configuration = configuration;
        }

        public SigningCredentials GetAudienceSigningKey(JwtCertified jwtCertified)
        {
            var privateKeyDirPath = string.Empty;

            switch (jwtCertified)
            {
                case JwtCertified.User:
                    privateKeyDirPath = _configuration["JwtUser:PrivateKeyDir"];
                    break;
                case JwtCertified.Customer:
                    privateKeyDirPath = _configuration["JwtCustomer:PrivateKeyDir"];
                    break;
            }

            string privateXmlKey = File.ReadAllText(privateKeyDirPath);
            rsa.FromXmlString(privateXmlKey);

            return new SigningCredentials(
                key: new RsaSecurityKey(rsa),
                algorithm: SecurityAlgorithms.RsaSha256);
        }

        public void Dispose()
        {
            rsa?.Dispose();
        }
    }
}
