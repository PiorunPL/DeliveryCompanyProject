using DeliveryCompany.Domain.Courier;

namespace DeliveryCompany.Application.Interfaces.Persistence;

public interface ICourierRepository
{
    public void Add(Courier Courier);
    public void Remove(Courier Courier);
    public Courier? GetCourierByEmail(string email);
    public List<Courier> GetAllCouriers();
}