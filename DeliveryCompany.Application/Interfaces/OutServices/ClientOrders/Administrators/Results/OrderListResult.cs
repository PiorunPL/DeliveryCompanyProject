using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrators.Results;

public record OrderListResult(
    List<ClientOrder> Orders
);