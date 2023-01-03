namespace DeliveryCompany.Infrastructure.Persistence.Facilities.Interfaces;

public interface IAssignment
{
    public List<Guid> GetAllCouriersByFacilityId(Guid facilityId);
    public string? GetFacilityIdByCourierId(Guid courierId);
    public void UpdateAssignment(List<Guid> couriersId, Guid facilityId);
}