using DeliveryCompany.Domain.Orders.Entities;

namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator.Results;

public record OrderResult(CourierOrder? CourierOrder);