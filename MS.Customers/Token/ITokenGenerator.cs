using MS.Customer.Domain.Entities;
using System;

namespace MS.Customer.API.Token
{
    public interface ITokenGenerator
    {
        string GenerateToken(Customers customer, Guid establishmentId);
    }
}