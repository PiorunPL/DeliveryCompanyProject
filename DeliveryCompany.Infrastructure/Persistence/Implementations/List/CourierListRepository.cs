using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.List;

public class CourierListRepository : ICourierRepository
{
    private static readonly List<Courier> Couriers = new();

    public void Add(Courier courier)
    {
        Couriers.Add(courier);
    }

    public Courier? GetCourierByEmail(string email)
    {
        return Couriers.SingleOrDefault(courier => courier.Email == email);
    }

    public Courier? GetCourierById(Guid id)
    {
        return Couriers.SingleOrDefault(courier => courier.Id.Value.Equals(id));
    }

    public List<Courier> GetAllCouriers()
    {
        return Couriers.ToList();
    }

    public void Remove(Courier courier)
    {
        Couriers.Remove(courier);
    }
}