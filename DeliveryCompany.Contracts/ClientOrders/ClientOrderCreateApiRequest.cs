namespace DeliveryCompany.Contracts.ClientOrders;

public record ClientOrderCreateApiRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    string SizeName,
    DateTime DateSent,
    DateTime DateDelivery
    // ,Guid ClientId
);