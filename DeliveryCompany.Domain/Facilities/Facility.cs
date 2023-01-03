using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Facilities.ValueObjects;

namespace DeliveryCompany.Domain.Facilities;

public class Facility : Entity<FacilityId>
{
    public string Address { get; set; }
    public string Name { get; set; }
    public FacilityStatus Status { get; set; }
    public List<Guid> CouriersId = new List<Guid>();

    public Facility(
        FacilityId id,
        string address,
        string? name
    ) : base(id)
    {
        Address = address;
        Name = GetCorrectName(name, id);
        Status = FacilityStatus.Open;
        LogFacilityCreated();
    }

    public static Facility Create(
        string address,
        string? name)
    {
        return new(
            FacilityId.CreateUnique(),
            address,
            name
        );
    }

    private string GetCorrectName(string? name, FacilityId id)
    {
        if (name == null || name.Equals(""))
        {
            return id.Value.ToString();
        }
        else
        {
            return name;
        }
    }

    private void LogFacilityCreated(){
        string log = "Facility created:";
        log += $"\n\tFacility ID: {Id.Value.ToString()}";
        log += $"\n\tName: {Name}";
        log += $"\n\tAddress: {Address}";
        log += $"\n\tStatus: {Status}";
        Console.WriteLine(log);
    }
}