using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes.ValueObjects;
using DeliveryCompany.Infrastructure.Persistence.ClientOrders.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.ClientOrders.Implementations;

public class ClientOrdersList : IClientOrders
{
    private readonly List<ClientOrderDto> _clientOrdersDb = new List<ClientOrderDto>();

    public void Add(ClientOrder clientOrder)
    {
        ClientOrderDto? found = _clientOrdersDb.Find(dto => dto.OrderId.Equals(clientOrder.Id.Value.ToString()));
        if (found is not null)
            return;
        ClientOrderDto dto = MapToDto(clientOrder);
        _clientOrdersDb.Add(dto);
    }

    public void Update(ClientOrder clientOrder)
    {
        ClientOrderDto dto = MapToDto(clientOrder);
        ClientOrderDto? foundDto = _clientOrdersDb.Find(foundDto => foundDto.OrderId == dto.OrderId);
        if (foundDto is not null)
            _clientOrdersDb.Remove(foundDto);
        _clientOrdersDb.Add(dto);
    }

    public List<ClientOrder> GetByClientId(PersonId clientId)
    {
        List<ClientOrderDto> clientsOrdersDb =
            _clientOrdersDb.FindAll(dto => dto.ClientId.Equals(clientId.Value.ToString()));
        return MapFromDtoList(clientsOrdersDb);
    }

    public ClientOrder? GetByOrderId(ClientOrderId orderId)
    {
        ClientOrderDto? dto = _clientOrdersDb.Find(dto => dto.OrderId.Equals(orderId.Value.ToString()));
        if (dto is null)
            return null;
        ClientOrder clientOrder = MapFromDto(dto);
        return clientOrder;
    }

    public List<ClientOrder> GetByStatus(ClientOrderStatus status)
    {
        List<ClientOrderDto> dtos = _clientOrdersDb.FindAll(dto => dto.Status == (int)status);
        return MapFromDtoList(dtos);
    }

    public List<ClientOrder> GetAll()
    {
        return MapFromDtoList(_clientOrdersDb);
    }

    private List<ClientOrder> MapFromDtoList(List<ClientOrderDto> dtos)
    {
        List<ClientOrder> clientOrders = new List<ClientOrder>();
        foreach (ClientOrderDto dto in dtos)
        {
            ClientOrder order = MapFromDto(dto);
            clientOrders.Add(order);
        }

        return clientOrders;
    }

    private ClientOrderDto MapToDto(ClientOrder clientOrder)
    {
        ClientOrderDto dto = new ClientOrderDto(
            clientOrder.Id.Value.ToString(),
            clientOrder.ClientId.Value.ToString(),
            clientOrder.DateOfExpectedSent,
            clientOrder.DateOfExpectedDelivery,
            clientOrder.AddressSent,
            clientOrder.AddressDelivery,
            clientOrder.Name,
            clientOrder.SizeId.Value.ToString(),
            (int)clientOrder.Status
        );
        return dto;
    }

    private ClientOrder MapFromDto(ClientOrderDto dto)
    {
        ClientOrder order = new ClientOrder(
            new ClientOrderId(Guid.Parse(dto.OrderId)),
            new PersonId(Guid.Parse(dto.ClientId)),
            dto.DateOfExpectedSent,
            dto.DateOfExpectedDelivery,
            dto.AddressSource,
            dto.AddressDestination,
            dto.Name,
            new SizeId(Guid.Parse(dto.SizeId)),
            (ClientOrderStatus)dto.Status);
        return order;
    }

    private class ClientOrderDto
    {
        public ClientOrderDto(string orderId, string clientId, DateTime dateOfExpectedSent,
            DateTime dateOfExpectedDelivery, string addressSource, string addressDestination, string name,
            string sizeId, int status)
        {
            OrderId = orderId;
            this.ClientId = clientId;
            this.DateOfExpectedSent = dateOfExpectedSent;
            this.DateOfExpectedDelivery = dateOfExpectedDelivery;
            this.AddressSource = addressSource;
            this.AddressDestination = addressDestination;
            this.Name = name;
            this.SizeId = sizeId;
            this.Status = status;
        }

        public string OrderId { get; set; }
        public string ClientId { get; set; }
        public DateTime DateOfExpectedSent { get; set; }
        public DateTime DateOfExpectedDelivery { get; set; }
        public string AddressSource { get; set; }
        public string AddressDestination { get; set; }
        public string Name { get; set; }
        public string SizeId { get; set; }
        public int Status { get; set; }
    }
}