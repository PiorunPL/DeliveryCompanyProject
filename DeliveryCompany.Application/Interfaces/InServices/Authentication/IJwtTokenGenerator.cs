using DeliveryCompany.Domain.Administrators;
using DeliveryCompany.Domain.Clients;
using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Interfaces.InServices.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(Client user);
    string GenerateToken(Courier courier);
    string GenerateToken(Administrator administrator);
}