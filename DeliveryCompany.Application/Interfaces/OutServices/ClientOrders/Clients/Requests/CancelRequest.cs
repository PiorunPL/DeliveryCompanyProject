namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;

public record CancelRequest(
    Guid OrderId,
    Guid ClientId
);