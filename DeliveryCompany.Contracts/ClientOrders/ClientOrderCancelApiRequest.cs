namespace DeliveryCompany.Contracts.ClientOrders;

public record ClientOrderCancelApiRequest(
    Guid OrderId
);