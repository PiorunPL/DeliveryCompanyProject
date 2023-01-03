using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface ICourierRepository
{
    public void Add(Courier Courier);
    public void Remove(Courier Courier);
    public Courier? GetCourierByEmail(string email);
    public Courier? GetCourierById(Guid id);
    public List<Courier> GetAllCouriers();
}