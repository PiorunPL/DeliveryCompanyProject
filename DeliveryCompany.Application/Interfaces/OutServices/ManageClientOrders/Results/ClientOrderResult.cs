using DeliveryCompany.Domain.Orders;

namespace DeliveryCompany.Application.Interfaces.ManageClientOrders.Results;

public record ClientOrderResult(
    ClientOrder order
);