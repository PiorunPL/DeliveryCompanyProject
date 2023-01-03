using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator.Results;

public record OrderResult(
    ClientOrder order  //TODO: Change ClientOrder object to muptiple basic types
);