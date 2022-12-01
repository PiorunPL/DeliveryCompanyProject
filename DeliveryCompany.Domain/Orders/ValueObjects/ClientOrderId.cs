using DeliveryCompany.Domain.Common.Models;

namespace DeliveryCompany.Domain.Orders.ValueObjects;

public sealed class ClientOrderId : ValueObject
{
    public Guid Value { get; }

    private ClientOrderId(Guid value){
        Value = value;
    }

    public static ClientOrderId CreateUnique(){
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents(){
        yield return Value;
    }
}
