namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrators.Requests;

public record CreateOrderRequest(
    Guid ClientOrderId, 
    Guid FacilitySentId,
    Guid FacilityDeliveryId);