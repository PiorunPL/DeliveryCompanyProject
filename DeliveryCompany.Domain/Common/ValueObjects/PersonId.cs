using DeliveryCompany.Domain.Common.Models;

namespace DeliveryCompany.Domain.Common.ValueObjects;

public sealed class PersonId : ValueObject
{
    public Guid Value { get; }

    public PersonId(Guid value)
    {
        Value = value;
    }

    public static PersonId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}