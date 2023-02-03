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
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ClientOrders;

public class ClientManage : IClientManage
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ISizeRepository _sizeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ILogger<ClientManage> _logger;

    public ClientManage(IClientOrderRepository clientOrderRepository, ILogger<ClientManage> logger,
        ISizeRepository sizeRepository, IClientRepository clientRepository)
    {
        _clientOrderRepository = clientOrderRepository;
        _logger = logger;
        _sizeRepository = sizeRepository;
        _clientRepository = clientRepository;
    }

    public ClientOrderResult CancelClientOrder(CancelRequest request)
    {
        ClientOrder order =
            Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        if (!order.Status.Equals(ClientOrderStatus.New))
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
        if (size is null)
        {
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

    public void ShareOrder(Guid clientId, Guid orderId, string sharedToEmail)
    {
        if (!Validator.ValidateEmail(sharedToEmail))
            throw new ArgumentException("Data is not valid!");

        Client? client = _clientRepository.GetClientById(clientId);
        if (client is null)
            throw new ArgumentException("Client with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetClientOrderById(new ClientOrderId(orderId));
        if (clientOrder is null)
            throw new ArgumentException("Client Order with given ID does not exist!");

        Client? foundClient = _clientRepository.GetClientById(clientOrder.ClientId.Value);
        if (foundClient is null)
            throw new Exception("Client order does not have its Client!");

        if (!foundClient.Id.Value.Equals(client.Id.Value))
            throw new ArgumentException("You are not an owner of a clientOrder!");

        Client? sharedToClient = _clientRepository.GetClientByEmail(sharedToEmail);
        if (sharedToClient is null)
            throw new ArgumentException("Client do not exist!");

        clientOrder.SharedToClients.Add(sharedToClient.Id);

        _clientOrderRepository.Update(clientOrder);
    }

    public string? GetImage(Guid clientId, Guid orderId)
    {
        Client? client = _clientRepository.GetClientById(clientId);
        if (client is null)
            throw new ArgumentException("Client with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetClientOrderById(new ClientOrderId(orderId));
        if (clientOrder is null)
            throw new ArgumentException("Client Order with given ID does not exist!");

        Client? foundClient = _clientRepository.GetClientById(clientOrder.ClientId.Value);
        if (foundClient is null)
            throw new Exception("Client order does not have its Client!");

        if (!foundClient.Id.Value.Equals(client.Id.Value) && !clientOrder.SharedToClients.Contains(client.Id)) 
            throw new ArgumentException("You are not an owner of a clientOrder!");

        var path = clientOrder.ImagePath;

        if (path is null)
            throw new Exception("There is no path!");

        using var stream = new MemoryStream(File.ReadAllBytes(path).ToArray());
        var based = Convert.ToBase64String(stream.ToArray());
        
        return based;
    }

    public ClientOrderResult GetOrder(GetRequest request)
    {
        ClientOrder order =
            Helper.ClientGetOrderWithValidation(request.ClientId, request.OrderId, _clientOrderRepository);

        //TODO: Possiblity - Sending only not hidden courier orders -> Probably good thing to create method in domain Model that return list of not hidden courier orders.

        return new ClientOrderResult(order);
    }

    public ClientOrderResult GetSharedOrder(GetRequest request)
    {
        Client? client = _clientRepository.GetClientById(request.ClientId);
        if (client is null)
            throw new ArgumentException("Client with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetClientOrderById(new ClientOrderId(request.OrderId));
        if (clientOrder is null)
            throw new ArgumentException("Client Order with given ID does not exist!");

        if (!clientOrder.SharedToClients.Contains(client.Id))
            throw new ArgumentException("Client not authorized!");

        return new ClientOrderResult(clientOrder);
    }

    public GetAllResult GetOrders(Guid clientId)
    {
        return new GetAllResult(_clientOrderRepository.GetAllClientOrdersByClientId(new PersonId(clientId)));
    }

    public GetAllResult GetOrdersShared(Guid clientId)
    {
        return new GetAllResult(_clientOrderRepository.GetAllClientOrdersSharedByClientId(new PersonId(clientId)));
    }

    public void SetImage(IFormFile file, Guid clientId, Guid orderId)
    {
        Client? client = _clientRepository.GetClientById(clientId);
        if (client is null)
            throw new ArgumentException("Client with given ID does not exist!");

        ClientOrder? clientOrder = _clientOrderRepository.GetClientOrderById(new ClientOrderId(orderId));
        if (clientOrder is null)
            throw new ArgumentException("Client Order with given ID does not exist!");

        Client? foundClient = _clientRepository.GetClientById(clientOrder.ClientId.Value);
        if (foundClient is null)
            throw new Exception("Client order does not have its Client!");

        if (!foundClient.Id.Value.Equals(client.Id.Value))
            throw new ArgumentException("You are not an owner of a clientOrder!");

        if (!Validator.ValidateImage(file))
            throw new ArgumentException("File is not valid!");

        //Save image
        var extension = Path.GetExtension(file.FileName);
        string filePath = Path.Combine("images", Guid.NewGuid().ToString() + extension);
        Console.WriteLine(filePath);

        Directory.CreateDirectory("images");
        Stream fileStream = new FileStream(filePath, FileMode.Create);
        file.CopyTo(fileStream);

        //TODO: check if imagepath exists, if yes, delete file

        //Save path to client order
        clientOrder.ImagePath = filePath;

        //update client order
        _clientOrderRepository.Update(clientOrder);
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