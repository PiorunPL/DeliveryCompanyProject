using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class ClientMySqlRepository : IClientRepository
{
    private DeliveryDbContext _dbContext;

    public ClientMySqlRepository(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Client client)
    {
        _dbContext.Clients.Add(MapToDto(client));
        _dbContext.SaveChanges();
    }
    
    public Client? GetClientByEmail(string email)
    {
        Entities.Client? dto = _dbContext.Clients.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    private Entities.Client MapToDto(Client client)
    {
        Entities.Client dto = new Entities.Client();
        dto.Email = client.Email;
        dto.Clientid = client.Id.Value.ToString();
        dto.Password = client.Password;
        dto.Firstname = client.FirstName;
        dto.Lastname = client.LastName;
        return dto;
    }

    private Client MapFromDto(Entities.Client dto)
    {
        Client client = new Client(
            new PersonId(Guid.Parse(dto.Clientid)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password);

        return client;
    }
}