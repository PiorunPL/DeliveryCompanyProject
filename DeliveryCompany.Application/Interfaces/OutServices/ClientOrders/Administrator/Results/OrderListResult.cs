using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator.Results;

public record OrderListResult(
    List<ClientOrder> Orders
);