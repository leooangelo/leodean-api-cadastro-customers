using MS.Customer.Domain.Enum;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Customer.Infra.Certificates.Interfaces
{
    public interface ISigningIssuerCertificate
    {
        RsaSecurityKey GetIssuerSigningKey(JwtCertified jwtCertified);
    }
}
