using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class CourierMySqlRepository : ICourierRepository
{
    private readonly NewDeliveryDbContext _dbContext;

    public CourierMySqlRepository(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(Courier courier)
    {
        _dbContext.Couriers.Add(MapToDto(courier));
        _dbContext.SaveChanges();
    }

    public void Remove(Courier courier)
    {
        _dbContext.Couriers.Remove(MapToDto(courier));
        _dbContext.SaveChanges();
    }

    public Courier? GetCourierByEmail(string email)
    {
        CourierDto? dto = _dbContext.Couriers.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public Courier? GetCourierById(Guid id)
    {
        CourierDto? dto = _dbContext.Couriers.SingleOrDefault(dto => dto.CourierId.Equals(id.ToString()));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<Courier> GetAllCouriers()
    {
        List<Courier> couriers = new List<Courier>();
        List<CourierDto> dtos = _dbContext.Couriers.ToList();
        foreach (CourierDto dto in dtos)
        {
            couriers.Add(MapFromDto(dto));
        }

        return couriers;
    }

    private Courier MapFromDto(CourierDto dto)
    {
        Courier courier = new Courier(
            new PersonId(Guid.Parse(dto.CourierId)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password,
            dto.Salt,
            dto.Datebirth,
            dto.Address);
        return courier;
    }

    private CourierDto MapToDto(Courier courier)
    {
        CourierDto dto = new CourierDto
        {
            CourierId = courier.Id.Value.ToString(),
            Firstname = courier.FirstName,
            Lastname = courier.LastName,
            Email = courier.Email,
            Password = courier.PasswordHash,
            Salt = courier.Salt,
            Datebirth = courier.DateBirth,
            Address = courier.Address,
        };
        return dto;
    }
}