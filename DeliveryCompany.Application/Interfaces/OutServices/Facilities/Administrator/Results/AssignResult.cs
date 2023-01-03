using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Domain.Facilities;

namespace DeliveryCompany.Application.Interfaces.OutServices.Facilities.Administrator.Results;

public record AssignResult(
    Courier Courier,
    Facility Facility);