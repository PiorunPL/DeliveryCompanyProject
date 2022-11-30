using DeliveryCompany.Domain.Administrator;
using DeliveryCompany.Domain.Courier;
using DeliveryCompany.Domain.Client;

namespace DeliveryCompany.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(Client user);
    string GenerateToken(Courier courier);
    string GenerateToken(Administrator administrator);
}