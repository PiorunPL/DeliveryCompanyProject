using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface IClientRepository
{
    Client? GetClientByEmail(string email);
    Client? GetClientById(Guid Id);
    void Add(Client client);
    void Update(Client client);
}