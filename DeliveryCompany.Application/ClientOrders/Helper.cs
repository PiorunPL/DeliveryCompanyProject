using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.ClientOrders;

public class Helper{
    public static ClientOrder ClientGetOrderWithValidation(Guid ClientId, Guid orderId, IClientOrderRepository repository)
    {
        ClientOrder order = GetOrder(orderId, repository);

        PersonId clientId = new PersonId(ClientId);
        if (!order.ClientId.Equals(clientId))
            throw new UnauthorizedAccessException("User with given ID have no permission to cancel that Client Order");

        return order;
    }

    public static ClientOrder GetOrder(Guid OrderId, IClientOrderRepository repository)
    {
        ClientOrderId orderId = new ClientOrderId(OrderId);
        ClientOrder? order = repository.GetClientOrderById(orderId);

        if (order is null)
            throw new ArgumentException("Order with given ID does not exist");
        return order;
    }
}