using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Results;

public record ClientOrderResult(
    ClientOrder Order   //TODO: Change ClientOrder object to multiple basic types
);