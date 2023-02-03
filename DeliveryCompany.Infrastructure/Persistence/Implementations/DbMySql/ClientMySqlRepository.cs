using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Clients;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class ClientMySqlRepository : IClientRepository
{
    private NewDeliveryDbContext _dbContext;

    public ClientMySqlRepository(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Client? GetClientById(Guid id)
    {
        ClientDto? dto = _dbContext.Clients.SingleOrDefault(dto => dto.ClientId.Equals(id.ToString()));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public void Add(Client client)
    {
        _dbContext.Clients.Add(MapToDto(client));
        _dbContext.SaveChanges();
    }

    public void Update(Client client)
    {
        ClientDto? dto = _dbContext.Clients.SingleOrDefault(dto => dto.Email.Equals(client.Email));
        if (dto is not null)
            _dbContext.Remove(dto);
        _dbContext.Add(MapToDto(client));
        _dbContext.SaveChanges();
    }

    public Client? GetClientByEmail(string email)
    {
        ClientDto? dto = _dbContext.Clients.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    private ClientDto MapToDto(Client client)
    {
        ClientDto dto = new ClientDto();
        dto.Email = client.Email;
        dto.ClientId = client.Id.Value.ToString();
        dto.Password = client.PasswordHash;
        dto.Salt = client.Salt;
        dto.Firstname = client.FirstName;
        dto.Lastname = client.LastName;
        dto.HashedCode = client.HashedCode;
        dto.CodeSalt = client.CodeSalt;
        return dto;
    }

    private Client MapFromDto(ClientDto dto)
    {
        Client client = new Client(
            new PersonId(Guid.Parse(dto.ClientId)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password,
            dto.Salt,
            dto.HashedCode,
            dto.CodeSalt);

        return client;
    }
}