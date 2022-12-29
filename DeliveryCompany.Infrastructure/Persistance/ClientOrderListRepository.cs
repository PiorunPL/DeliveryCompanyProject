using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Infrastructure.Persistance;

public class ClientOrderListRepository : IClientOrderRepository
{
    private static readonly List<ClientOrder> _clientOrders = new List<ClientOrder>();
    public void Add(ClientOrder order)
    {
        _clientOrders.Add(order);
    }

    public void Update(ClientOrder order)
    {
        if(_clientOrders.Contains(order))
        {
            _clientOrders.Remove(order);
            _clientOrders.Add(order);
        }
    }

    public List<ClientOrder> GetAllClientOrdersByClientId(PersonId id)
    {
        return _clientOrders.Where(co => co.ClientId.Equals(id)).ToList();
    }

    public List<ClientOrder> GetAllClientOrdersWithGivenStatus(ClientOrderStatus status)
    {
        return _clientOrders.Where(co => co.Status.Equals(status)).ToList();
    }

    public ClientOrder? GetClientOrderById(ClientOrderId id)
    {
        return _clientOrders.SingleOrDefault(co => co.Id.Equals(id));
    }

    public List<ClientOrder> GetAllClientOrders()
    {
        return _clientOrders.ToList();
    }
}
