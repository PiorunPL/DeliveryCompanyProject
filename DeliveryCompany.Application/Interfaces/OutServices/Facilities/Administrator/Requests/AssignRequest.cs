namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Requests;

public record AssignRequest(
    Guid CourierId,
    Guid FacilityId);