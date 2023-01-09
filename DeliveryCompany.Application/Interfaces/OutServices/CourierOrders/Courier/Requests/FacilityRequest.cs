using DeliveryCompany.Domain.Facilities.ValueObjects;

namespace DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Requests;

public record FacilityRequest(
    Guid FacilityId);