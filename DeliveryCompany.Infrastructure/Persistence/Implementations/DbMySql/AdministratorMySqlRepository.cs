using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Administrators;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class AdministratorMySqlRepository : IAdministratorRepository
{
    private readonly NewDeliveryDbContext _dbContext;

    public AdministratorMySqlRepository(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Administrator administrator)
    {
        _dbContext.Add(MapToDto(administrator));
        _dbContext.SaveChanges();
    }

    public void Remove(Administrator administrator)
    {
        _dbContext.Remove(MapToDto(administrator));
        _dbContext.SaveChanges();
    }

    public Administrator? GetAdministratorByEmail(string email)
    {
        AdministratorDto? dto = _dbContext.Administrators.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<Administrator> GetAllAdministrators()
    {
        List<Administrator> administrators = new List<Administrator>();
        List<AdministratorDto> dtos = _dbContext.Administrators.ToList();
        foreach (AdministratorDto dto in dtos)
        {
            administrators.Add(MapFromDto(dto));
        }

        return administrators;
    }

    private AdministratorDto MapToDto(Administrator administrator)
    {
        AdministratorDto dto = new AdministratorDto
        {
            Datebirth = administrator.DateBirth,
            Firstname = administrator.FirstName,
            Address = administrator.Address,
            Lastname = administrator.LastName,
            Password = administrator.Password,
            AdministratorId = administrator.Id.Value.ToString(),
            Email = administrator.Email
        };
        return dto;
    }

    private Administrator MapFromDto(AdministratorDto dto)
    {
        Administrator administrator = new Administrator(
            new PersonId(Guid.Parse(dto.AdministratorId)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password,
            dto.Datebirth,
            dto.Address);
        return administrator;
    }
}