namespace DeliveryCompany.Contracts.ClientOrders.Clients.Requests;

public record ClientOrderCancelApiRequest(
    Guid OrderId
);