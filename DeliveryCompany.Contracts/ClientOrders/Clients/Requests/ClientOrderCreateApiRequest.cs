namespace DeliveryCompany.Contracts.ClientOrders.Clients.Requests;

public record ClientOrderCreateApiRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    string SizeName,
    DateTime DateSent,
    DateTime DateDelivery
    // ,Guid ClientId
);