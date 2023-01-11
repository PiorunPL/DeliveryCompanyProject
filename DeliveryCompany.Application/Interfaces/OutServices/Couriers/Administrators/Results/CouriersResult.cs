using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Results;

public record CouriersResult(
    List<Courier> Couriers);