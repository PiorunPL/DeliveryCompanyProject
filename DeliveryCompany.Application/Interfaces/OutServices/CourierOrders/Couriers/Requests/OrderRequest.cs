namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers.Requests;

public record OrderRequest(Guid OrderId, Guid CourierId);