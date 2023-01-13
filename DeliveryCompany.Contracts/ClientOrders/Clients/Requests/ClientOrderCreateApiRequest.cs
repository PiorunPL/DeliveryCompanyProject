namespace DeliveryCompany.Contracts.ClientOrders.Clients.Requests;

public record ClientOrderCreateApiRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    Guid SizeId,
    DateTime DateSent,
    DateTime DateDelivery
    // ,Guid ClientId
);