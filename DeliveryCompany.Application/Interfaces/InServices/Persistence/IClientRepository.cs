using DeliveryCompany.Domain.Clients;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface IClientRepository
{
    Client? GetClientByEmail(string email);
    void Add(Client client);
}