using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Results;

public record FacilitiesResult(
    List<Facility> Facilities);