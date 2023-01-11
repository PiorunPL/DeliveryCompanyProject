using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Results;

public record FacilityListResult(
    List<Facility> Facilities);