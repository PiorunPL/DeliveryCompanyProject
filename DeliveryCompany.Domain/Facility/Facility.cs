using System.Reflection.Metadata;
using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Facility.ValueObjects;

namespace DeliveryCompany.Domain.Facility;

public class Facility : Entity<FacilityId>
{
    public string Address { get; set; }
    public string Name { get; set; }

    private Facility(
        FacilityId id,
        string address,
        string name
    ) : base(id)
    {
        Address = address;
        Name = getCorrectName(name, id);
    }

    public static Facility Create(
        string address,
        string name)
    {
        return new(
            FacilityId.CreateUnique(),
            address,
            name
        );
    }

    private string getCorrectName(string name, FacilityId id)
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
}