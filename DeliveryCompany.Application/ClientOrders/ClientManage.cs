using DeliveryCompany.Application.Authentication.Common;
using DeliveryCompany.Application.Interfaces.InServices.Persistence;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Requests;
using DeliveryCompany.Application.Interfaces.OutServices.ClientOrders.Clients.Results;
using DeliveryCompany.Domain.Clients;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ClientOrders;

public class ClientManage : IClientManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ISizeRepository _sizeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<ClientManage> _logger;

    public ClientManage(IClientOrderRepository clientOrderRepository, ILogger<ClientManage> logger, ISizeRepository sizeRepository, IClientRepository clientRepository)
    {
        _clientOrderRepository = clientOrderRepository;
        _logger = logger;
        _sizeRepository = sizeRepository;
        _clientRepository = clientRepository;
    }

    public ClientOrderResult CancelClientOrder(CancelRequest request)
    {   
        ClientOrder order = Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        if(!order.Status.Equals(ClientOrderStatus.New))
            throw new ApplicationException("Order can be cancelled only when order status is New");

        order.Status = ClientOrderStatus.Cancelled;
        _clientOrderRepository.Update(order);

        return new ClientOrderResult(order);
    }

    public Task<ClientOrderResult> CreateNewClientOrderAsync(CreateRequest request)
    {
        return Task.Run((() => CreateNewClientOrder(request)));
    }
    
    public ClientOrderResult CreateNewClientOrder(CreateRequest request)
    {
        if (!ValidateCreateData(request))
            throw new ArgumentException("Data is not valid!");

        Client? client = _clientRepository.GetClientById(request.ClientId);
        if (client is null)
            throw new AggregateException("Client with given Id does not exist");
        
        Size? size = _sizeRepository.GetById(request.SizeId);
        if(size is null){
            throw new ArgumentException("Given Size does not exist!");
        }
        
        if (request.DateSent >= request.DateDelivery || request.DateSent < DateTime.UtcNow)
            throw new ArgumentException("Date is not valid!");
        
        string name = request.Name.Equals("") ? request.ClientId.ToString() : request.Name;
        
        PersonId id = new PersonId(request.ClientId);

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

        _clientOrderRepository.Add(order);

        return new ClientOrderResult(order);
    }

    public ClientOrderResult GetOrder(GetRequest request)
    {
        ClientOrder order = Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        //TODO: Possiblity - Sending only not hidden courier orders -> Probably good thing to create method in domain Model that return list of not hidden courier orders.
        
        return new ClientOrderResult(order);
    }

    public GetAllResult GetOrders(Guid clientId)
    {
        return new GetAllResult(_clientOrderRepository.GetAllClientOrdersByClientId(new PersonId(clientId)));
    }

    private bool ValidateCreateData(CreateRequest request)
    {
        if (!Validator.ValidateAddress(request.AddressDelivery))
            return false;
        if (!Validator.ValidateAddress(request.AddressSent))
            return false;
        if (!Validator.ValidatePackageName(request.Name))
            return false;

        return true;
    }
    
    
}
