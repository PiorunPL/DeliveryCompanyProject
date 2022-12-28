using DeliveryCompany.Application.Interfaces.ClientOrders;
using DeliveryCompany.Application.Interfaces.ClientOrders.Requests;
using DeliveryCompany.Application.Interfaces.ClientOrders.Results;
using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ManageClientOrders;

public class ClientManage : IClientManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ILogger<ClientManage> _logger;

    public ClientManage(IClientOrderRepository clientOrderRepository, ILogger<ClientManage> logger)
    {
        _clientOrderRepository = clientOrderRepository;
        _logger = logger;
    }

    public ClientOrderResult CancelClientOrder(ClientOrderCancelRequest request)
    {   
        ClientOrder order = GetClientOrder(request.ClientId, request.OrderId);

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

    public ClientOrderResult CreateNewClientOrder(ClientOrderCreateRequest request)
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

    public ClientOrderResult GetOrder(ClientOrderGetRequest request)
    {
        ClientOrder order = GetClientOrder(request.ClientId, request.OrderId);

        //TODO: Possiblity - Sending only not hidden courier orders -> Probably good thing to create method in domain Model that return list of not hidden courier orders.

        //Return order result
        return new ClientOrderResult(order);
    }

    public void GetOrders()
    {
        throw new NotImplementedException();
    }

    private ClientOrder GetClientOrder(Guid ClientId, Guid OrderId)
    {
        ClientOrderId orderId = new ClientOrderId(OrderId);
        ClientOrder? order = _clientOrderRepository.GetClientOrderById(orderId);
        
        //TODO: Log Check Order exist
        //Check if Order with given exist
        if(order is null)
            throw new ArgumentException("Order with given ID does not exist");

        //TODO: Log Check If Order belongs to client
        //Check if order is connected with given client
        PersonId clientId = new PersonId(ClientId);
        if(!order.ClientId.Equals(clientId))
            throw new UnauthorizedAccessException("User with given ID have no permission to cancel that Client Order");

        return order;
    }
}