using DeliveryCompany.Domain.Common.Models;

namespace DeliveryCompany.Domain.Size.ValueObjects;

public sealed class SizeId : ValueObject
{
    public Guid Value { get; }

    private SizeId(Guid value)
    {
        Value = value;
    }

    public static SizeId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}