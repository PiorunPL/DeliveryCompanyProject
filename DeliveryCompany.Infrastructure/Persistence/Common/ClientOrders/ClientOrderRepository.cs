using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders;

public class ClientOrderRepository : IClientOrderRepository
{
    private readonly IClientOrders _clientOrders;
    private readonly ICourierOrders _courierOrders;
    private readonly ISharedOrders _sharedOrders;

    public ClientOrderRepository(IClientOrders clientOrders, ICourierOrders courierOrders, ISharedOrders sharedOrders)
    {
        _clientOrders = clientOrders;
        _courierOrders = courierOrders;
        _sharedOrders = sharedOrders;
    }

    public void Add(ClientOrder order)
    {
        _clientOrders.Add(order);
        _courierOrders.Update(order);
        _sharedOrders.Update(order);
    }

    public void Update(ClientOrder order)
    {
        _clientOrders.Update(order);
        _courierOrders.Update(order);
        _sharedOrders.Update(order);
    }

    public ClientOrder? GetClientOrderById(ClientOrderId id)
    {
        ClientOrder? clientOrder = _clientOrders.GetByOrderId(id);
        if (clientOrder is null)
            return null;

        List<CourierOrder> courierOrders = _courierOrders.GetByClientOrderId(id);
        clientOrder.CourierOrders.AddRange(courierOrders);

        List<PersonId> personIds = _sharedOrders.GetByClientOrderId(id);
        clientOrder.SharedToClients.AddRange(personIds);

        return clientOrder;
    }

    public List<ClientOrder> GetAllClientOrdersByClientId(PersonId id)
    {
        List<ClientOrder> clientOrders = _clientOrders.GetByClientId(id);
        
        foreach (ClientOrder order in clientOrders)
        {
            List<CourierOrder> courierOrders = _courierOrders.GetByClientOrderId(order.Id);
            order.CourierOrders.AddRange(courierOrders);
            
            List<PersonId> personIds = _sharedOrders.GetByClientOrderId(order.Id);
            order.SharedToClients.AddRange(personIds);
        }

        return clientOrders;
    }

    public List<ClientOrder> GetAllClientOrdersWithGivenStatus(ClientOrderStatus status)
    {
        List<ClientOrder> clientOrders = _clientOrders.GetByStatus(status);
        foreach (ClientOrder order in clientOrders)
        {
            List<CourierOrder> courierOrders = _courierOrders.GetByClientOrderId(order.Id);
            order.CourierOrders.AddRange(courierOrders);
            
            List<PersonId> personIds = _sharedOrders.GetByClientOrderId(order.Id);
            order.SharedToClients.AddRange(personIds);
        }

        return clientOrders;
    }

    public List<ClientOrder> GetAllClientOrders()
    {
        List<ClientOrder> clientOrders = _clientOrders.GetAll();
        foreach (ClientOrder order in clientOrders)
        {
            List<CourierOrder> courierOrders = _courierOrders.GetByClientOrderId(order.Id);
            order.CourierOrders.AddRange(courierOrders);
            
            List<PersonId> personIds = _sharedOrders.GetByClientOrderId(order.Id);
            order.SharedToClients.AddRange(personIds);
        }

        return clientOrders;
    }

    public ClientOrder? GetByCourierOrderId(CourierOrderId id)
    {
        (CourierOrder? courierOrder, ClientOrderId? clientOrderId) = _courierOrders.GetByCourierOrderId(id);

        if (courierOrder is null || clientOrderId is null)
            return null;
        
        ClientOrder? clientOrder = GetClientOrderById(clientOrderId);

        if (clientOrder is null)
            return null;
        
        List<CourierOrder> courierOrders = _courierOrders.GetByClientOrderId(clientOrderId);
        clientOrder.CourierOrders.AddRange(courierOrders);

        List<PersonId> personIds = _sharedOrders.GetByClientOrderId(clientOrderId);
        clientOrder.SharedToClients.AddRange(personIds);
        
        return clientOrder;
    }
}