namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Requests;

public record CancelRequest(
    Guid OrderId,
    Guid ClientId
);