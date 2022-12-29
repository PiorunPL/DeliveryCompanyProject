using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Administrator.Results;

public record OrderListResult(
    List<ClientOrder> Orders
);