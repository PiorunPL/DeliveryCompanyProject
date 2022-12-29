using System.Runtime.Intrinsics.X86;
using DeliveryCompany.Application.Interfaces.ClientOrders.Administrator;
using DeliveryCompany.Application.Interfaces.ClientOrders.Administrator.Requests;
using DeliveryCompany.Application.Interfaces.ClientOrders.Administrator.Results;
using DeliveryCompany.Application.Interfaces.Persistence;
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
        if(!order.Status.Equals(ClientOrderStatus.New))
            throw new ApplicationException("Status for given Order is diffrent than New"); 

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
        throw new NotImplementedException();
    }

    public OrderListResult GetAllActiveOrders()
    {
        throw new NotImplementedException();
    }

    public OrderListResult GetAllOrders()
    {
        throw new NotImplementedException();
    }

    public OrderResult GetOrder(OrderRequest request)
    {
        throw new NotImplementedException();
    }

    public OrderResult SubmitOrderRoute(OrderRequest request)
    {
        throw new NotImplementedException();
    }
}