namespace DeliveryCompany.Contracts.ClientOrders;

public record ClientOrderAPIClientResponse(
    Guid ClientId,
    Guid OrderId,
    DateTime DateSent,
    DateTime DateDelivered,
    string AddressSent,
    string AddressDelivery,
    string Name,
    Guid SizeId,
    string Status
);