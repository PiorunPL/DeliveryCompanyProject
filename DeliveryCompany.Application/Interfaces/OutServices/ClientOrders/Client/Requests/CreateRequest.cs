using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Sizes;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Requests;

public record CreateRequest(
    string AddressSent,
    string AddressDelivery,
    string Name,
    string SizeName,
    DateTime DateSent,
    DateTime DateDelivery,
    Guid ClientId
);