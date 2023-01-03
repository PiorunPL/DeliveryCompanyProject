using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Infrastructure.Persistence;

public class ClientListRepository : IClientRepository
{
    private static readonly List<Client> _users = new();
    public void Add(Client user)
    {
        _users.Add(user);
    }

    public Client? GetClientByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}