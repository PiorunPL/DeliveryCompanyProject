using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Requests;

public record ClientOrderCreateRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    string SizeName,
    DateTime DateSent,
    DateTime DateDelivery,
    Guid ClientId
);