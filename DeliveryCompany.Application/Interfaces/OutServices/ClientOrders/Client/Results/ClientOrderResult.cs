using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Results;

public record ClientOrderResult(
    ClientOrder Order   //TODO: Change ClientOrder object to multiple basic types
);