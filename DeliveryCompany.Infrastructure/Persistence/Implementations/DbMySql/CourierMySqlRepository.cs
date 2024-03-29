using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Infrastructure.Context;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql;

public class CourierMySqlRepository : ICourierRepository
{
    private readonly DeliveryDbContext _dbContext;

    public CourierMySqlRepository(DeliveryDbContext dbContext)
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
        Entities.Courier? dto = _dbContext.Couriers.SingleOrDefault(dto => dto.Email.Equals(email));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public Courier? GetCourierById(Guid id)
    {
        Entities.Courier? dto = _dbContext.Couriers.SingleOrDefault(dto => dto.Courierid.Equals(id.ToString()));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<Courier> GetAllCouriers()
    {
        List<Courier> couriers = new List<Courier>();
        List<Entities.Courier> dtos = _dbContext.Couriers.ToList();
        foreach (Entities.Courier dto in dtos)
        {
            couriers.Add(MapFromDto(dto));
        }

        return couriers;
    }

    private Courier MapFromDto(Entities.Courier dto)
    {
        Courier courier = new Courier(
            new PersonId(Guid.Parse(dto.Courierid)),
            dto.Firstname,
            dto.Lastname,
            dto.Email,
            dto.Password,
            dto.Datebirth,
            dto.Address);
        return courier;
    }

    private Entities.Courier MapToDto(Courier courier)
    {
        Entities.Courier dto = new Entities.Courier
        {
            Courierid = courier.Id.Value.ToString(),
            Firstname = courier.FirstName,
            Lastname = courier.LastName,
            Email = courier.Email,
            Password = courier.Password,
            Datebirth = courier.DateBirth,
            Address = courier.Address,
        };
        return dto;
    }
}