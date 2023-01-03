namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Requests;

public record CreateFacilityRequest(
    string Address,
    string Name);