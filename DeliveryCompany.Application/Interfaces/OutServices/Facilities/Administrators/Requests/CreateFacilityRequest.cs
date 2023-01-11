namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Requests;

public record CreateFacilityRequest(
    string Address,
    string Name);