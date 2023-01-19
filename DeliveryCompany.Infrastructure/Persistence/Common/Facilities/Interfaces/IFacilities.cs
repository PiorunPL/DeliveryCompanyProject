using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;

public interface IFacilities
{
    public List<Facility> GetAllFacilities();
    public Facility? GetFacilityById(Guid givenId);
    public void AddFacility(Facility facility);
    public void UpdateFacility(Facility facility);
}