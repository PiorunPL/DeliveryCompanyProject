using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.ClientOrders;

public class ClientOrderMySql : IClientOrders
{
    private readonly NewDeliveryDbContext _dbContext;

    public ClientOrderMySql(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(ClientOrder clientOrder)
    {
        ClientOrderDto? dto =
            _dbContext.ClientOrders.SingleOrDefault(dto => dto.OrderId.Equals(clientOrder.Id.Value.ToString()));
        if (dto is not null)
            return;
        _dbContext.ClientOrders.Add(MapToDto(clientOrder));
        _dbContext.SaveChanges();
    }

    public void Update(ClientOrder clientOrder)
    {
        ClientOrderDto? dto =
            _dbContext.ClientOrders.SingleOrDefault(dto => dto.OrderId.Equals(clientOrder.Id.Value.ToString()));
        if (dto is null)
        {
            _dbContext.ClientOrders.Add(MapToDto(clientOrder));
            _dbContext.SaveChanges();
            return;
        }

        dto.Name = clientOrder.Name;
        dto.AddressDelivery = clientOrder.AddressDelivery;
        dto.AddressSent = clientOrder.AddressSent;
        dto.ClientId = clientOrder.ClientId.Value.ToString();
        dto.SizeId = clientOrder.SizeId.Value.ToString();
        dto.DateDelivered = clientOrder.DateOfExpectedDelivery;
        dto.DateSent = clientOrder.DateOfExpectedSent;
        dto.Status = clientOrder.Status.ToString();
        dto.PathToImage = clientOrder.ImagePath;
        _dbContext.ClientOrders.Update(dto);
        _dbContext.SaveChanges();
    }

    public List<ClientOrder> GetByClientId(PersonId clientId)
    {
        List<ClientOrder> orders = new List<ClientOrder>();
        ClientDto? client =
            _dbContext.Clients.Include(client => client.ClientOrders)
                .SingleOrDefault(dto => dto.ClientId.Equals(clientId.Value.ToString()));
        if (client is null)
            return orders; //TODO: Przemyśleć czy nie exception

        foreach (var dto in client.ClientOrders.ToList())
        {
            orders.Add(MapFromDto(dto));
        }

        return orders;
    }

    public ClientOrder? GetByOrderId(ClientOrderId orderId)
    {
        ClientOrderDto? dto =
            _dbContext.ClientOrders.SingleOrDefault(dto => dto.OrderId.Equals(orderId.Value.ToString()));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<ClientOrder> GetByStatus(ClientOrderStatus status)
    {
        List<ClientOrder> clientOrders = new List<ClientOrder>();
        List<ClientOrderDto> dtos = _dbContext.ClientOrders.Where(dto => dto.Status.Equals(status.ToString()))
            .ToList();
        foreach (var dto in dtos)
        {
            clientOrders.Add(MapFromDto(dto));
        }

        return clientOrders;
    }

    public List<ClientOrder> GetAll()
    {
        List<ClientOrder> clientOrders = new List<ClientOrder>();
        List<ClientOrderDto> dtos = _dbContext.ClientOrders.ToList();
        foreach (var dto in dtos)
        {
            clientOrders.Add(MapFromDto(dto));
        }

        return clientOrders;
    }

    private ClientOrderDto MapToDto(ClientOrder clientOrder)
    {
        ClientOrderDto dto = new ClientOrderDto
        {
            OrderId = clientOrder.Id.Value.ToString(),
            AddressDelivery = clientOrder.AddressDelivery,
            AddressSent = clientOrder.AddressSent,
            ClientId = clientOrder.ClientId.Value.ToString(),
            DateDelivered = clientOrder.DateOfExpectedDelivery,
            DateSent = clientOrder.DateOfExpectedSent,
            SizeId = clientOrder.SizeId.Value.ToString(),
            Name = clientOrder.Name,
            Status = clientOrder.Status.ToString(),
            PathToImage = clientOrder.ImagePath
        };
        return dto;
    }

    private ClientOrder MapFromDto(ClientOrderDto dto)
    {
        ClientOrder clientOrder = new ClientOrder(
            new ClientOrderId(Guid.Parse(dto.OrderId)),
            new PersonId(Guid.Parse(dto.ClientId)),
            dto.DateSent,
            dto.DateDelivered,
            dto.AddressSent,
            dto.AddressDelivery,
            dto.Name,
            new SizeId(Guid.Parse(dto.SizeId)),
            Enum.Parse<ClientOrderStatus>(dto.Status));

        clientOrder.ImagePath = dto.PathToImage;
        
        return clientOrder;
    }
}