using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Client.Results;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ClientOrders;

public class ClientManage : IClientManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ILogger<ClientManage> _logger;

    public ClientManage(IClientOrderRepository clientOrderRepository, ILogger<ClientManage> logger)
    {
        _clientOrderRepository = clientOrderRepository;
        _logger = logger;
    }

    public ClientOrderResult CancelClientOrder(CancelRequest request)
    {   
        ClientOrder order = Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        //TODO: Log Check if order status is new
        //Check if order status is new
        if(!order.Status.Equals(ClientOrderStatus.New))
            throw new ApplicationException("Order can be cancelled only when order status is New");

        //TODO: Log Cancelling order
        //Set client order to Cancelled status
        order.Status = ClientOrderStatus.Cancelled;

        //TODO: Log updating repository
        //Update repository
        _clientOrderRepository.Update(order);

        //Return order result
        return new ClientOrderResult(order);
    }

    public ClientOrderResult CreateNewClientOrder(CreateRequest request)
    {
        //TODO: ValidateData 
        // - check if User with given ID exists
        
        string name = request.Name.Equals("") ? request.ClientId.ToString() : request.Name;

        //TODO: Log Getting Size
        Size? size = Sizes.ManageSizes.GetSizeFromName(request.SizeName);

        if(size is null){
            //TODO: Log Size invalid
            throw new ArgumentException("Given Size Name is invalid!");
        }

        PersonId id = new PersonId(request.ClientId);

        //TODO: Log Creating ClientOrder
        ClientOrder order = ClientOrder.Create(
            id,
            request.DateSent,
            request.DateDelivery,
            request.AddressSent,
            request.AddressDelivery,
            name,
            size.Id,
            ClientOrderStatus.New
        );

        //TODO: Log adding ClientOrder to repository
        _clientOrderRepository.Add(order);

        return new ClientOrderResult(order);
    }

    public ClientOrderResult GetOrder(GetRequest request)
    {
        ClientOrder order = Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        //TODO: Possiblity - Sending only not hidden courier orders -> Probably good thing to create method in domain Model that return list of not hidden courier orders.

        //Return order result
        return new ClientOrderResult(order);
    }

    public GetAllResult GetOrders(Guid clientId)
    {
        //TODO: LOG getting all client orders with given clientId
        return new GetAllResult(_clientOrderRepository.GetAllClientOrdersByClientId(new PersonId(clientId)));
    }

    
}
