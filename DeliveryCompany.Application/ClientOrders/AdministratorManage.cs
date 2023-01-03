using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Administrator.Results;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ClientOrders;

public class AdministratorManage : IAdministratorManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ILogger<AdministratorManage> _logger;

    public AdministratorManage(ILogger<AdministratorManage> logger, IClientOrderRepository clientOrderRepository)
    {
        _logger = logger;
        _clientOrderRepository = clientOrderRepository;
    }

    public OrderResult AcceptOrder(OrderRequest request)
    {
        //Get Client Order
        //TODO: Log getting Client Order
        ClientOrder order = Helper.GetOrder(request.OrderId, _clientOrderRepository);

        //Check if status is NEW
        // TODO: Log Status Checking
        if (order.Status != ClientOrderStatus.New)
            throw new ApplicationException("Status for given Order is different than New");

        //Change Status to accepted
        // TODO: Log Status Changing
        order.Status = ClientOrderStatus.Accepted;


        //Update Client Order in repository
        // TODO: Log Updating Repository
        _clientOrderRepository.Update(order);

        //Return changed client order
        return new OrderResult(order);
    }

    public OrderResult CancelOrder(OrderRequest request)
    {
        //Get Client Order
        //TODO: Log Getting Client Order
        ClientOrder order = Helper.GetOrder(request.OrderId, _clientOrderRepository);

        //Check if status is Accepted
        //TODO: Log Status Checking
        if (order.Status != ClientOrderStatus.Accepted)
            throw new ApplicationException("Status for given Order is different than Accepted");

        //Change status to Canceled
        //TODO: Log Status Changing
        order.Status = ClientOrderStatus.Cancelled;

        //Update Client Order in repository
        // TODO: Log updating repository
        _clientOrderRepository.Update(order);

        //Return changed client order
        return new OrderResult(order);
    }

    public OrderListResult GetAllActiveOrders()
    {
        // TODO: Log getting Active ClientOrders
        List<ClientOrder> ordersNew = _clientOrderRepository.GetAllClientOrdersWithGivenStatus(ClientOrderStatus.New);
        List<ClientOrder> ordersAccepted = _clientOrderRepository.GetAllClientOrdersWithGivenStatus(ClientOrderStatus.Accepted);
        List<ClientOrder> ordersInProgress = _clientOrderRepository.GetAllClientOrdersWithGivenStatus(ClientOrderStatus.InProgress);
        List<ClientOrder> activeOrders = ordersAccepted
            .Concat(ordersNew)
            .Concat(ordersInProgress)
            .ToList();

        return new OrderListResult(activeOrders);
    }

    public OrderListResult GetAllOrders()
    {
        // TODO: Log Getting client orders
        return new OrderListResult(_clientOrderRepository.GetAllClientOrders());
    }

    public OrderResult GetOrder(OrderRequest request)
    {
        //TODO: Log getting client Order
        return new OrderResult(Helper.GetOrder(request.OrderId, _clientOrderRepository));
    }

    public OrderResult SubmitOrderRoute(OrderRequest request)
    {
        //Get Client Order
        ClientOrder order = Helper.GetOrder(request.OrderId, _clientOrderRepository);

        //Check if Status is ACCEPTED
        if (order.Status != ClientOrderStatus.Accepted)
            throw new ApplicationException("Status for given Order is different than Accepted");

        //TODO: Check if all routes from source to destination are created 

        //Change Status to InProgress
        order.Status = ClientOrderStatus.InProgress;

        //TODO: Change First Courier Order status to Free

        //Update Repository
        _clientOrderRepository.Update(order);

        //Return Client Order
        return new OrderResult(order);
    }
}