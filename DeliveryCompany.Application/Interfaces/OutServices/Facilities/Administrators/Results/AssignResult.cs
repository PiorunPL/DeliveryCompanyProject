using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrators.Results;

public record AssignResult(
    Courier Courier,
    Facility Facility);