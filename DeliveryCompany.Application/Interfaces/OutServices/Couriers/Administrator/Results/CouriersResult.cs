using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrator.Results;

public record CouriersResult(
    List<Courier> Couriers);