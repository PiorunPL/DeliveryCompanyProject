using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Client.Results;

public record ClientOrderResult(
    ClientOrder order
);