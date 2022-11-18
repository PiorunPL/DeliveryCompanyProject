using DeliveryCompany.Domain.User;

namespace DeliveryCompany.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}