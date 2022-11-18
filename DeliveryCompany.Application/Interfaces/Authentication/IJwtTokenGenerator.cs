using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator{
    string GenerateToken(User user);
}