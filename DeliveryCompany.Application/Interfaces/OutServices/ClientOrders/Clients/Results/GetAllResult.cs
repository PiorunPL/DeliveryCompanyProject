using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;

public record GetAllResult(
    List<ClientOrder> Orders
);