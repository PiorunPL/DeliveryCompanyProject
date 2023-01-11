namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;

public record GetRequest(
    Guid OrderId,
    Guid ClientId
);