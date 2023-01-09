namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator.Requests;

public record CreateOrderRequest(
    Guid ClientOrderId, 
    Guid FacilitySentId,
    Guid FacilityDeliveryId);