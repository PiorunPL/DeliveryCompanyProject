namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Couriers.Requests;

public record FacilityRequest(
    Guid FacilityId,
    Guid CourierId);