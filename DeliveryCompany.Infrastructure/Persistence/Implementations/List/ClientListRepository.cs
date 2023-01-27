using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.List;

public class ClientListRepository : IClientRepository
{
    private static readonly List<Client> _users = new();
    public Client? GetClientById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public void Add(Client user)
    {
        _users.Add(user);
    }

    public void Update(Client client)
    {
        throw new NotImplementedException();
    }

    public Client? GetClientByEmail(string email)
    {
        return _users.SingleOrDefault(u => u.Email == email);
    }
}