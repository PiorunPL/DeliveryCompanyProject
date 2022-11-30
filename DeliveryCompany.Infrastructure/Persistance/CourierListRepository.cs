using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Courier;

namespace DeliveryCompany.Infrastructure.Persistance;

public class CourierListRepository : ICourierRepository
{
    private static readonly List<Courier> _Couriers = new();

    public void Add(Courier Courier)
    {
        _Couriers.Add(Courier);
    }

    public Courier? GetCourierByEmail(string email)
    {
        return _Couriers.SingleOrDefault(courier => courier.Email == email);
    }

    public List<Courier> GetAllCouriers()
    {
        return _Couriers.ToList();
    }

    public void Remove(Courier Courier)
    {
        _Couriers.Remove(Courier);
    }
}