using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.Interfaces.InServices.Persistence;

public interface IClientOrderRepository
{
    public void Add(ClientOrder order);
    public void Update(ClientOrder order);
    public ClientOrder? GetClientOrderById(ClientOrderId id);
    public List<ClientOrder> GetAllClientOrdersByClientId(PersonId id);
    public List<ClientOrder> GetAllClientOrdersWithGivenStatus(ClientOrderStatus status);
    public List<ClientOrder> GetAllClientOrders();
    public ClientOrder? GetByCourierOrderId(CourierOrderId id);
}