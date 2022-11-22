using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}