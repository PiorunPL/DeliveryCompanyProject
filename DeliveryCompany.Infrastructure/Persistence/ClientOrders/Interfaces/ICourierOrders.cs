using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Infrastructure.Persistence.ClientOrders.Interfaces;

public interface ICourierOrders
{
    public void Update(ClientOrder clientOrder);
    public List<CourierOrder> GetByClientOrderId(ClientOrderId clientOrderId);
    public CourierOrder? GetByCourierOrderId(CourierOrderId courierOrderId);
}