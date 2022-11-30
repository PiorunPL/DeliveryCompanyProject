using DeliveryCompany.Domain.Client;

namespace DeliveryCompany.Application.Interfaces.Persistence;

public interface IClientRepository
{
    Client? GetClientByEmail(string email);
    void Add(Client client);
}