using DeliveryCompany.Domain.Facilities;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.Facilities;

public class FacilitiesMySql : IFacilities
{
    private readonly DeliveryDbContext _dbContext;

    public FacilitiesMySql(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Facility> GetAllFacilities()
    {
        List<Facility> facilities = new List<Facility>();
        List<Entities.Facility> dtos = _dbContext.Facilities.ToList();

        foreach (var dto in dtos)
        {
            facilities.Add(MapFromDto(dto));
        }

        return facilities;
    }

    public Facility? GetFacilityById(Guid givenId)
    {
        Entities.Facility? foundDto =
            _dbContext.Facilities.SingleOrDefault(dto => dto.Facilityid.Equals(givenId.ToString()));
        if (foundDto is null)
            return null;
        return MapFromDto(foundDto);
    }

    public void AddFacility(Facility facility)
    {
        Entities.Facility? foundDto =
            _dbContext.Facilities.SingleOrDefault(dto => dto.Facilityid.Equals(facility.Id.Value.ToString()));
        if (foundDto is not null)
            return;
        _dbContext.Facilities.Add(MapToDto(facility));
        _dbContext.SaveChanges();
    }

    public void UpdateFacility(Facility facility)
    {
        _dbContext.Facilities.Update(MapToDto(facility));
        _dbContext.SaveChanges();
    }

    private Entities.Facility MapToDto(Facility facility)
    {
        Entities.Facility dto = new Entities.Facility
        {
            Facilityid = facility.Id.Value.ToString(),
            Address = facility.Address,
            Name = facility.Name
        };
        return dto;
    }

    private Facility MapFromDto(Entities.Facility dto)
    {
        Facility facility = new Facility(
            new FacilityId(Guid.Parse(dto.Facilityid)),
            dto.Address,
            dto.Name);
        return facility;
    }
}