using DeliveryCompany.Domain.Common.Models;

namespace DeliveryCompany.Domain.Facilities.ValueObjects;

public class FacilityId : ValueObject
{
    public Guid Value {get;}

    public FacilityId(Guid value)
    {
        Value = value;
    }

    public static FacilityId CreateUnique(){
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}