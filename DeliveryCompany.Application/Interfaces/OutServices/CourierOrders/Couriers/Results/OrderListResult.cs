using DeliveryCompany.Domain.Orders.Entities;

namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers.Results;

public record OrderListResult(
    List<CourierOrder> CourierOrders);