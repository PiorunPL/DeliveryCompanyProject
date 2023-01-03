using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Infrastructure.Persistence;

public class FacilityRepository : IFacilityRepository
{
    public void Add(Facility facility)
    {
        throw new NotImplementedException();
    }

    public void Update(Facility facility)
    {
        throw new NotImplementedException();
    }

    public Facility? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Facility? GetByCourierId(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Facility> GetFacilities()
    {
        throw new NotImplementedException();
    }
}