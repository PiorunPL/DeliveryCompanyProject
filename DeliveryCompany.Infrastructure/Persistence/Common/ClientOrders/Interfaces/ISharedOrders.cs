using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;

public interface ISharedOrders
{
    public void Update(ClientOrder clientOrder);
    public List<PersonId> GetByClientOrderId(ClientOrderId clientOrderId);
}