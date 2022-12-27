namespace DeliveryCompany.Application.Interfaces.ManageClientOrders.Requests;

public record ClientOrderCancelRequest(
    Guid OrderId,
    Guid ClientId
);