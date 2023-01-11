namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Requests;

public record AssignRequest(
    Guid CourierId,
    Guid FacilityId);