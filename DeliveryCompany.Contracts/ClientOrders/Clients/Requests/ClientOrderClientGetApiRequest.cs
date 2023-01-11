namespace DeliveryCompany.Contracts.ClientOrders.Clients.Requests;

public record ClientOrderClientGetApiRequest(
    Guid OrderId
);