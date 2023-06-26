using Microsoft.IdentityModel.Tokens;
using MS.Customer.Domain.Enum;

namespace MS.Customer.Infra.AsymmetricEncryption
{
    public interface ISigningAudienceCertificate
    {
        SigningCredentials GetAudienceSigningKey(JwtCertified jwtCertified);
    }
}
