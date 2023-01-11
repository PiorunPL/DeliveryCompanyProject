using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;

public record ClientOrderResult(
    ClientOrder Order   //TODO: Change ClientOrder object to multiple basic types
);