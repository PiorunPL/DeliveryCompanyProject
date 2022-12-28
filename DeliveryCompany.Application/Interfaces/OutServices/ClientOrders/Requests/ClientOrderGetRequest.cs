namespace DeliveryCompany.Application.Interfaces.ClientOrders.Requests;

public record ClientOrderGetRequest(
    Guid OrderId,
    Guid ClientId
);