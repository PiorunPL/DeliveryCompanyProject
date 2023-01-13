namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;

public record CreateRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    Guid SizeId,
    DateTime DateSent,
    DateTime DateDelivery,
    Guid ClientId
);