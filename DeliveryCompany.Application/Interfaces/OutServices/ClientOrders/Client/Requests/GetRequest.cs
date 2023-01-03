namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Requests;

public record GetRequest(
    Guid OrderId,
    Guid ClientId
);