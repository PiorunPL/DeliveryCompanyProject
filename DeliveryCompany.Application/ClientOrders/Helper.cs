using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.ClientOrders;

public class Helper{
    public static ClientOrder ClientGetOrderWithValidation(Guid ClientId, Guid OrderId, IClientOrderRepository repository)
    {
        ClientOrder order = GetOrder(OrderId, repository);

        //TODO: Log Check If Order belongs to client
        //Check if order is connected with given client
        PersonId clientId = new PersonId(ClientId);
        if (!order.ClientId.Equals(clientId))
            throw new UnauthorizedAccessException("User with given ID have no permission to cancel that Client Order");

        return order;
    }

    public static ClientOrder GetOrder(Guid OrderId, IClientOrderRepository repository)
    {
        ClientOrderId orderId = new ClientOrderId(OrderId);
        ClientOrder? order = repository.GetClientOrderById(orderId);

        //TODO: Log Check Order exist
        //Check if Order with given exist
        if (order is null)
            throw new ArgumentException("Order with given ID does not exist");
        return order;
    }
}