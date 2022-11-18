using DeliveryCompany.Domain.Administrator;
using DeliveryCompany.Domain.Courier;
using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
    string GenerateToken(Courier courier);
    string GenerateToken(Administrator administrator);
}