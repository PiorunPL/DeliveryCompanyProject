using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.Facilities;

public class AssignmentMySql : IAssignment
{
    private readonly DeliveryDbContext _dbContext;

    public AssignmentMySql(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Guid> GetAllCouriersByFacilityId(Guid facilityId)
    {
        List<Guid> listOfCouriersIds = new List<Guid>();
        List<Courier>? dtos = _dbContext.Facilities
            .SingleOrDefault(dto => dto.Facilityid.Equals(facilityId.ToString()))
            ?.Couriers.ToList();
        if (dtos is null)
            return listOfCouriersIds;
        foreach (var dto in dtos)
        {
            listOfCouriersIds.Add(Guid.Parse(dto.Courierid));
        }

        return listOfCouriersIds;
    }

    public string? GetFacilityIdByCourierId(Guid courierId)
    {
        Facility? facility = _dbContext.Couriers.SingleOrDefault(dto => dto.Courierid.Equals(courierId.ToString()))
            ?.Facilities.FirstOrDefault();
        if (facility is null)
            return null;
        return facility.Facilityid.ToString();
    }

    public void UpdateAssignment(List<Guid> couriersId, Guid facilityId)
    {
        Facility? facility = _dbContext.Facilities.SingleOrDefault(dto => dto.Facilityid.Equals(facilityId.ToString()));
        if (facility is null)
            return;
        
        facility.Couriers.Clear();
        
        foreach (var id in couriersId)
        {
            Courier? courier = _dbContext.Couriers.SingleOrDefault(dto => dto.Courierid.Equals(id.ToString()));
            if (courier is not null)
            {
                facility.Couriers.Add(courier);
            }
        }

        _dbContext.SaveChanges();
    }
}