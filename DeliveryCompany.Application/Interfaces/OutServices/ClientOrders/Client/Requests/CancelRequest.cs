namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Requests;

public record CancelRequest(
    Guid OrderId,
    Guid ClientId
);