using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Results;

public record GetAllResult(
    List<ClientOrder> Orders
);