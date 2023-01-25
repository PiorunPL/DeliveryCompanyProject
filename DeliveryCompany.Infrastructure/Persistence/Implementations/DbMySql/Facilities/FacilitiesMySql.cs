using DeliveryCompany.Domain.Facilities;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.Facilities;

public class FacilitiesMySql : IFacilities
{
    private readonly NewDeliveryDbContext _dbContext;

    public FacilitiesMySql(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public List<Facility> GetAllFacilities()
    {
        List<Facility> facilities = new List<Facility>();
        List<FacilityDto> dtos = _dbContext.Facilities.ToList();

        foreach (var dto in dtos)
        {
            facilities.Add(MapFromDto(dto));
        }

        return facilities;
    }

    public Facility? GetFacilityById(Guid givenId)
    {
        FacilityDto? foundDto =
            _dbContext.Facilities.SingleOrDefault(dto => dto.FacilityId.Equals(givenId.ToString()));
        if (foundDto is null)
            return null;
        return MapFromDto(foundDto);
    }

    public void AddFacility(Facility facility)
    {
        FacilityDto? foundDto =
            _dbContext.Facilities.SingleOrDefault(dto => dto.FacilityId.Equals(facility.Id.Value.ToString()));
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

    private FacilityDto MapToDto(Facility facility)
    {
        FacilityDto dto = new FacilityDto
        {
            FacilityId = facility.Id.Value.ToString(),
            Address = facility.Address,
            Name = facility.Name
        };
        return dto;
    }

    private Facility MapFromDto(FacilityDto dto)
    {
        Facility facility = new Facility(
            new FacilityId(Guid.Parse(dto.FacilityId)),
            dto.Address,
            dto.Name);
        return facility;
    }
}