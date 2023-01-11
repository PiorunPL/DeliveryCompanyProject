using DeliveryCompany.Domain.Orders.Entities;

namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrators.Results;

public record OrderListResult(List<CourierOrder> CourierOrders);