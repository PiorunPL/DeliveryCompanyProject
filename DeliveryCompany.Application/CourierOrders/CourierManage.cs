using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.CourierOrders.Courier.Results;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Couriers;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Application.CourierOrders;

public class CourierManage : ICourierManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ICourierRepository _courierRepository;

    public CourierManage(IClientOrderRepository clientOrderRepository, ICourierRepository courierRepository)
    {
        _clientOrderRepository = clientOrderRepository;
        _courierRepository = courierRepository;
    }

    public OrderListResult GetAvailableForFacility(FacilityRequest request)
    {
        List<ClientOrder> clientOrdersInProgress =
            _clientOrderRepository.GetAllClientOrdersWithGivenStatus(ClientOrderStatus.InProgress);

        List<CourierOrder> courierOrders = new List<CourierOrder>();

        foreach (ClientOrder clientOrder in clientOrdersInProgress)
        {
            CourierOrder? foundOrder =
                Common.GetActiveCourierOrderByResponsibleFacility(clientOrder, new FacilityId(request.FacilityId));
            if (foundOrder is not null)
                courierOrders.Add(foundOrder);
        }

        return new OrderListResult(courierOrders);
    }

    public OrderListResult GetAllByCourier(CourierRequest request)
    {
        List<ClientOrder> clientOrders = _clientOrderRepository.GetAllClientOrders();
        List<CourierOrder> courierOrders = new List<CourierOrder>();

        foreach (ClientOrder clientOrder in clientOrders)
        {
            List<CourierOrder> foundOrders = clientOrder.CourierOrders.FindAll(order =>
                order.CourierId is not null && order.CourierId.Equals(new PersonId(request.CourierId)));
            courierOrders.AddRange(foundOrders);
        }

        return new OrderListResult(courierOrders);
    }

    public OrderResult Accept(OrderRequest request)
    {
        CourierOrderId courierOrderId = new CourierOrderId(request.OrderId);
        PersonId courierId = new PersonId(request.CourierId);

        Courier? courier = _courierRepository.GetCourierById(courierId.Value);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetByCourierOrderId(courierOrderId);
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with given courier order ID");

        CourierOrder? courierOrder = clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Equals(courierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        if (!courierOrder.Status.Equals(CourierOrderStatus.Free))
            throw new ApplicationException("Courier order needs to be in Status: Free");

        courierOrder.Status = CourierOrderStatus.InProgress;
        courierOrder.CourierId = courierId;

        _clientOrderRepository.Update(clientOrder);

        return new OrderResult(courierOrder);
    }

    public OrderResult Resign(OrderRequest request)
    {
        CourierOrderId courierOrderId = new CourierOrderId(request.OrderId);
        PersonId courierId = new PersonId(request.CourierId);

        Courier? courier = _courierRepository.GetCourierById(courierId.Value);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetByCourierOrderId(courierOrderId);
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with given courier order ID");

        CourierOrder? courierOrder = clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Equals(courierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        if (!courierOrder.Status.Equals(CourierOrderStatus.InProgress))
            throw new ApplicationException("Courier order needs to be in Status: InProgress");

        if (courierOrder.CourierId is null || !courierOrder.CourierId.Equals(courierId))
            throw new ArgumentException("Only courier associated with Order can resign");

        courierOrder.Status = CourierOrderStatus.Free;
        courierOrder.CourierId = null;

        _clientOrderRepository.Update(clientOrder);

        return new OrderResult(courierOrder);
    }

    public OrderResult PickUpPackage(OrderRequest request)
    {
        CourierOrderId courierOrderId = new CourierOrderId(request.OrderId);
        PersonId courierId = new PersonId(request.CourierId);

        Courier? courier = _courierRepository.GetCourierById(courierId.Value);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetByCourierOrderId(courierOrderId);
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with given courier order ID");

        CourierOrder? courierOrder = clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Equals(courierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        if (!courierOrder.Status.Equals(CourierOrderStatus.InProgress))
            throw new ApplicationException("Courier order needs to be in Status: InProgress");

        if (courierOrder.CourierId is null || !courierOrder.CourierId.Equals(courierId))
            throw new ArgumentException("Only courier associated with Order can resign");

        courierOrder.DateSent = DateTime.UtcNow;

        _clientOrderRepository.Update(clientOrder);

        return new OrderResult(courierOrder);
    }

    public OrderResult SetAsDelivered(OrderRequest request)
    {
        CourierOrderId courierOrderId = new CourierOrderId(request.OrderId);
        PersonId courierId = new PersonId(request.CourierId);

        Courier? courier = _courierRepository.GetCourierById(courierId.Value);
        if (courier is null)
            throw new ArgumentException("Courier with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetByCourierOrderId(courierOrderId);
        if (clientOrder is null)
            throw new ArgumentException("There is no client order associated with given courier order ID");

        CourierOrder? courierOrder = clientOrder.CourierOrders.FirstOrDefault(order => order.Id.Equals(courierOrderId));
        if (courierOrder is null)
            throw new ArgumentException("There is no courier order with given ID");

        if (!courierOrder.Status.Equals(CourierOrderStatus.InProgress))
            throw new ApplicationException("Courier order needs to be in Status: InProgress");

        if (courierOrder.CourierId is null || !courierOrder.CourierId.Equals(courierId))
            throw new ArgumentException("Only courier associated with Order can resign");

        courierOrder.DateDelivered = DateTime.UtcNow;
        courierOrder.Status = CourierOrderStatus.Delivered;
        
        CourierOrder? nextOrder = Common.GetNextCourierOrder(clientOrder, courierOrder);
        if (nextOrder is null)
        {
            clientOrder.Status = ClientOrderStatus.Delivered;
        }
        else
        {
            nextOrder.Status = CourierOrderStatus.Free;
        }

        _clientOrderRepository.Update(clientOrder);

        return new OrderResult(courierOrder);
    }
}