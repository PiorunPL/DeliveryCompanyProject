using DeliveryCompany.Domain.Couriers;

namespace DeliveryCompany.Application.Interfaces.OutServices.Couriers.Administrators.Results;

public record CourierListResult(
    List<Courier> Couriers);