using DeliveryCompany.Domain.Common.Models;

namespace DeliveryCompany.Domain.Orders.ValueObjects;

public sealed class CourierOrderId : ValueObject
{
    public Guid Value { get; }

    private CourierOrderId(Guid value){
        Value = value;
    }

    public static CourierOrderId CreateUnique(){
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents(){
        yield return Value;
    }
}