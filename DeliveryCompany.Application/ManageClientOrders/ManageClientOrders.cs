using DeliveryCompany.Application.Interfaces.ManageClientOrders;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Requests;
using DeliveryCompany.Application.Interfaces.ManageClientOrders.Results;
using DeliveryCompany.Application.Interfaces.Persistence;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes;
using Microsoft.Extensions.Logging;

namespace DeliveryCompany.Application.ManageClientOrders;

public class ManageClientOrders : IManageClientOrders
{
    private readonly IClientOrderRepository _clientOrderRepository;
    private readonly ILogger<ManageClientOrders> _logger;

    public ManageClientOrders(IClientOrderRepository clientOrderRepository, ILogger<ManageClientOrders> logger)
    {
        _clientOrderRepository = clientOrderRepository;
        _logger = logger;
    }

    public ClientOrderResult CancelClientOrder()
    {
        throw new NotImplementedException();
    }

    public ClientOrderResult CreateNewClientOrder(ClientOrderCreateRequest request)
    {
        //TODO: ValidateData
        
        string name = request.Name.Equals("") ? request.ClientId.ToString() : request.Name;

        //TODO: Log Getting Size
        Size? size = ManageSizes.ManageSizes.GetSizeFromName(request.SizeName);

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
        //TODO: Log added ClientOrder to repository

        return new ClientOrderResult(order);
    }

    public ClientOrderResult GetOrder()
    {
        throw new NotImplementedException();
    }

    public void GetOrders()
    {
        throw new NotImplementedException();
    }
}
