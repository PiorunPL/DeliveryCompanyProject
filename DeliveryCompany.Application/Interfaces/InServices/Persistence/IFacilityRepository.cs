using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface IFacilityRepository
{
    public void Add(Facility facility);
    public void Update(Facility facility);
    public Facility? GetById(Guid id);
    public Facility? GetByCourierId(Guid id);
    public List<Facility> GetFacilities();
}