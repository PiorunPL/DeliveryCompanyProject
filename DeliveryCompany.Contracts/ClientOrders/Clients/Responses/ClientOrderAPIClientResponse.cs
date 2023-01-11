namespace DeliveryCompany.Contracts.ClientOrders.Clients.Responses;

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