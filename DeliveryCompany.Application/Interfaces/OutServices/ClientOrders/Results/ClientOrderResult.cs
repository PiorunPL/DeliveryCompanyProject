using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ClientOrders.Results;

public record ClientOrderResult(
    ClientOrder order
);