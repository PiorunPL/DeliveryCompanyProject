namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;

public record CreateRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    string SizeName,
    DateTime DateSent,
    DateTime DateDelivery,
    Guid ClientId
);