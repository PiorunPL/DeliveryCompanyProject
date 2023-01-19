using DeliveryCompany.Domain.Facilities;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Infrastructure.Persistence.Common.Facilities.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.List.Facilities;

public class FacilitiesList : IFacilities
{
    private readonly List<FacilityDto> _facilitiesDb = new List<FacilityDto>();

    public List<Facility> GetAllFacilities()
    {
        List<Facility> facilitiesList = new List<Facility>();
        foreach (var dbFacility in _facilitiesDb)
        {
            try
            {
                Guid id = Guid.Parse(dbFacility.Id);
                FacilityId facilityId = new FacilityId(id);
                Facility facility = new Facility(
                    facilityId,
                    dbFacility.Address,
                    dbFacility.Name);
                facilitiesList.Add(facility);
            }
            catch (FormatException)
            {
            }
        }

        return facilitiesList;
    }

    public Facility? GetFacilityById(Guid givenId)
    {
        FacilityDto? facilityDto = _facilitiesDb.SingleOrDefault(facility => facility.Id == givenId.ToString());
        if (facilityDto is null)
            return null;

        Guid id = Guid.Parse(facilityDto.Id);
        FacilityId facilityId = new FacilityId(id);
        Facility facility = new Facility(
            facilityId,
            facilityDto.Address,
            facilityDto.Name);

        return facility;
    }

    public void AddFacility(Facility facility)
    {
        FacilityDto dto = new FacilityDto(
            facility.Id.Value.ToString(),
            facility.Name,
            facility.Address);
        _facilitiesDb.Add(dto);
    }

    public void UpdateFacility(Facility facility)
    {
        FacilityDto dto = new FacilityDto(
            facility.Id.Value.ToString(),
            facility.Name,
            facility.Address);

        FacilityDto? foundDto = _facilitiesDb.Find(facilityDto => facilityDto.Id == facility.Id.Value.ToString());
        if (foundDto is not null)
            _facilitiesDb.Remove(foundDto);

        _facilitiesDb.Add(dto);
    }

    private class FacilityDto
    {
        public FacilityDto(string id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}