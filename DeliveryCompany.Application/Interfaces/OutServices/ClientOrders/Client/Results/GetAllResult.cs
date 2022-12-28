using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Results;

public record GetAllResult(
    List<ClientOrder> Orders
);