using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.Facilities;

public class AssignmentMySql : IAssignment
{
    private readonly NewDeliveryDbContext _dbContext;

    public AssignmentMySql(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Guid> GetAllCouriersByFacilityId(Guid facilityId)
    {
        List<Guid> listOfCouriersIds = new List<Guid>();
        List<CourierDto>? dtos = _dbContext.Facilities
            .SingleOrDefault(dto => dto.FacilityId.Equals(facilityId.ToString()))
            ?.Couriers.ToList();
        if (dtos is null)
            return listOfCouriersIds;
        foreach (var dto in dtos)
        {
            listOfCouriersIds.Add(Guid.Parse(dto.CourierId));
        }

        return listOfCouriersIds;
    }

    public string? GetFacilityIdByCourierId(Guid courierId)
    {
        FacilityDto? facility = _dbContext.Couriers.SingleOrDefault(dto => dto.CourierId.Equals(courierId.ToString()))
            ?.Facilities.FirstOrDefault();
        if (facility is null)
            return null;
        return facility.FacilityId.ToString();
    }

    public void UpdateAssignment(List<Guid> couriersId, Guid facilityId)
    {
        FacilityDto? facility = _dbContext.Facilities.SingleOrDefault(dto => dto.FacilityId.Equals(facilityId.ToString()));
        if (facility is null)
            return;
        
        facility.Couriers.Clear();
        
        foreach (var id in couriersId)
        {
            CourierDto? courier = _dbContext.Couriers.SingleOrDefault(dto => dto.CourierId.Equals(id.ToString()));
            if (courier is not null)
            {
                facility.Couriers.Add(courier);
            }
        }

        _dbContext.SaveChanges();
    }
}