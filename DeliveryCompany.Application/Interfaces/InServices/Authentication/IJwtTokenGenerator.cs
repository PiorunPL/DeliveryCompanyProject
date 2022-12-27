using DeliveryCompany.Domain.Administrators;
using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(Client user);
    string GenerateToken(Courier courier);
    string GenerateToken(Administrator administrator);
}