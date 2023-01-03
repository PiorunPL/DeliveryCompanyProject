using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Facilities;
using DeliveryCompany.Infrastructure.Persistence.Facilities.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.Facilities;

public class FacilityRepository : IFacilityRepository
{
    private readonly IFacilities _facilities;
    private readonly IAssignment _assignment;
    
    public FacilityRepository(IFacilities facilities, IAssignment assignment)
    {
        _facilities = facilities;
        _assignment = assignment;
    }
    
    //TODO: Validation for Database entries
    public void Add(Facility facility)
    {   
        _facilities.AddFacility(facility);
        _assignment.UpdateAssignment(facility.CouriersId, facility.Id.Value);
    }

    public void Update(Facility facility)
    {
        _facilities.UpdateFacility(facility);
        _assignment.UpdateAssignment(facility.CouriersId, facility.Id.Value);
    }

    public Facility? GetById(Guid id)
    {
        Facility? facility = _facilities.GetFacilityById(id);
        if (facility is null)
            return facility;

        List<Guid> couriersId = _assignment.GetAllCouriersByFacilityId(id);
        facility.CouriersId.AddRange(couriersId);
        return facility;
    }

    public Facility? GetByCourierId(Guid courierId)
    {
        string? facilityIdString = _assignment.GetFacilityIdByCourierId(courierId);
        if (facilityIdString is null)
            return null;

        Guid facilityId = Guid.Parse(facilityIdString);
        Facility? facility = _facilities.GetFacilityById(facilityId);
        if (facility is null)
            return null;

        List<Guid> couriersByFacility = _assignment.GetAllCouriersByFacilityId(facilityId);
        facility.CouriersId.AddRange(couriersByFacility);

        return facility;
    }

    public List<Facility> GetFacilities()
    {
        List<Facility> facilities = _facilities.GetAllFacilities();
        foreach (var facility in facilities)
        {
            List<Guid> couriersId = _assignment.GetAllCouriersByFacilityId(facility.Id.Value);
            facility.CouriersId.AddRange(couriersId);
        }

        return facilities;
    }
}