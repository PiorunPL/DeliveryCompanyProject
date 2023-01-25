using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Administrators;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Infrastructure.Context;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class AdministratorMySqlRepository : IAdministratorRepository
{
    private readonly DeliveryDbContext _dbContext;

    public AdministratorMySqlRepository(DeliveryDbContext dbContext)
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
        Entities_BackUp.Administrator? dto = _dbContext.Administrators.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<Administrator> GetAllAdministrators()
    {
        List<Administrator> administrators = new List<Administrator>();
        List<Entities_BackUp.Administrator> dtos = _dbContext.Administrators.ToList();
        foreach (Entities_BackUp.Administrator dto in dtos)
        {
            administrators.Add(MapFromDto(dto));
        }

        return administrators;
    }

    private Entities_BackUp.Administrator MapToDto(Administrator administrator)
    {
        Entities_BackUp.Administrator dto = new Entities_BackUp.Administrator
        {
            Datebirth = administrator.DateBirth,
            Firstname = administrator.FirstName,
            Address = administrator.Address,
            Lastname = administrator.LastName,
            Password = administrator.Password,
            Administratorid = administrator.Id.Value.ToString(),
            Email = administrator.Email
        };
        return dto;
    }

    private Administrator MapFromDto(Entities_BackUp.Administrator dto)
    {
        Administrator administrator = new Administrator(
            new PersonId(Guid.Parse(dto.Administratorid)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password,
            dto.Datebirth,
            dto.Address);
        return administrator;
    }
}