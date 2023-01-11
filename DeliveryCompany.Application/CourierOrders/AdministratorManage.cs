using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Administrator.Results;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.CourierOrders;

public class AdministratorManage : IAdministratorManage
{
    private readonly IClientOrderRepository _clientOrderRepository;

    public AdministratorManage(IClientOrderRepository clientOrderRepository)
    {
        _clientOrderRepository = clientOrderRepository;
    }

    public OrderResult Create(CreateOrderRequest request)
    {
        ClientOrder? clientOrder = _clientOrderRepository.GetClientOrderById(new ClientOrderId(request.ClientOrderId));
        if (clientOrder is null)
            throw new ArgumentException("Client order with given ID does not exist!");

        if (request.FacilitySentId == Guid.Empty && request.FacilityDeliveryId == Guid.Empty)
            throw new ArgumentException("At least one of facilities needs to be specified!");

        CourierOrder courierOrder = CourierOrder.Create(
            new FacilityId(request.FacilitySentId),
            new FacilityId(request.FacilityDeliveryId));

        clientOrder.CourierOrders.Add(courierOrder);
        
        bool isValid = Common.CheckIfRouteIsCorrect(clientOrder.CourierOrders);

        if (isValid)
            clientOrder.CourierOrders = Common.SortCourierOrdersActiveFirst(clientOrder.CourierOrders);

        _clientOrderRepository.Update(clientOrder);

        return new OrderResult(courierOrder);
    }

    public OrderResult Cancel(OrderRequest request)
    {
        ClientOrder? clientOrder =
            _clientOrderRepository.GetByCourierOrderId(new CourierOrderId(request.CourierOrderId));
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with Courier order with given ID");

        if (!(clientOrder.Status.Equals(ClientOrderStatus.Cancelled) ||
              clientOrder.Status.Equals(ClientOrderStatus.Delivered)))
            throw new ArgumentException("Client order has already been completed");

        CourierOrder? courierOrder =
            clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Value.Equals(request.CourierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        if (!(courierOrder.Status.Equals(CourierOrderStatus.Hidden) ||
              courierOrder.Status.Equals(CourierOrderStatus.Free)))
            throw new ApplicationException("Courier orders only with status Free or Hidden can be cancelled!");

        courierOrder.Status = CourierOrderStatus.Cancelled;
        clientOrder.Status = ClientOrderStatus.Accepted; // This status requires from Administrator fixing route

        _clientOrderRepository.Update(clientOrder);
        return new OrderResult(courierOrder);
    }

    public OrderResult Get(OrderRequest request)
    {
        ClientOrder? clientOrder =
            _clientOrderRepository.GetByCourierOrderId(new CourierOrderId(request.CourierOrderId));
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with Courier order with given ID");

        CourierOrder? courierOrder =
            clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Value.Equals(request.CourierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        return new OrderResult(courierOrder);
    }

    public OrderListResult GetMissingForClientOrder(ClientOrderRequest request)
    {
        throw new NotImplementedException();
    }
}