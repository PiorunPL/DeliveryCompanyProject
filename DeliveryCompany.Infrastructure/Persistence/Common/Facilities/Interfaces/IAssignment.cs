namespace DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;

public interface IAssignment
{
    public List<Guid> GetAllCouriersByFacilityId(Guid facilityId);
    public string? GetFacilityIdByCourierId(Guid courierId);
    public void UpdateAssignment(List<Guid> couriersId, Guid facilityId);
}