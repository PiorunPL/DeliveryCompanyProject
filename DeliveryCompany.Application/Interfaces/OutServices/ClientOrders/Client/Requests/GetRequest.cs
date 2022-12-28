namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Requests;

public record GetRequest(
    Guid OrderId,
    Guid ClientId
);