namespace DeliveryCompany.Application.Interfaces.ClientOrders.Requests;

public record ClientOrderCancelRequest(
    Guid OrderId,
    Guid ClientId
);