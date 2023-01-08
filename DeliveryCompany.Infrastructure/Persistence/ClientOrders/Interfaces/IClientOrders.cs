using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Infrastructure.Persistence.ClientOrders.Interfaces;

public interface IClientOrders
{
    public void Add(ClientOrder clientOrder);
    public void Update(ClientOrder clientOrder);
    public List<ClientOrder> GetByClientId(PersonId clientId);
    public ClientOrder? GetByOrderId(ClientOrderId orderId);
    public List<ClientOrder> GetByStatus(ClientOrderStatus status);
    public List<ClientOrder> GetAll();
}