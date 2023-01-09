using DeliveryCompany.Domain.Orders.Entities;

namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Results;

public record OrderListResult(
    List<CourierOrder> CourierOrders);