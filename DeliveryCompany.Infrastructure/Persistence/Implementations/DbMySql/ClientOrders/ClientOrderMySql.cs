using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Domain.Sizes.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;
using DeliveryCompany.Infrastructure.Persistence.Entities_BackUp;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.ClientOrders;

public class ClientOrderMySql : IClientOrders
{
    private readonly DeliveryDbContext _dbContext;

    public ClientOrderMySql(DeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(ClientOrder clientOrder)
    {
        Clientorder? dto =
            _dbContext.Clientorders.SingleOrDefault(dto => dto.Orderid.Equals(clientOrder.Id.Value.ToString()));
        if (dto is not null)
            return;
        _dbContext.Clientorders.Add(MapToDto(clientOrder));
        _dbContext.SaveChanges();
    }

    public void Update(ClientOrder clientOrder)
    {
        Clientorder? dto =
            _dbContext.Clientorders.SingleOrDefault(dto => dto.Orderid.Equals(clientOrder.Id.Value.ToString()));
        if (dto is null)
        {
            _dbContext.Clientorders.Add(MapToDto(clientOrder));
            _dbContext.SaveChanges();
            return;
        }

        dto.Name = clientOrder.Name;
        dto.Addressdelivery = clientOrder.AddressDelivery;
        dto.Addresssent = clientOrder.AddressSent;
        dto.Clientid = clientOrder.ClientId.Value.ToString();
        dto.Sizeid = clientOrder.SizeId.Value.ToString();
        dto.Datedelivered = clientOrder.DateOfExpectedDelivery;
        dto.Datesent = clientOrder.DateOfExpectedSent;
        dto.Status = clientOrder.Status.ToString();
        _dbContext.Clientorders.Update(dto);
        _dbContext.SaveChanges();
    }

    public List<ClientOrder> GetByClientId(PersonId clientId)
    {
        List<ClientOrder> orders = new List<ClientOrder>();
        Client? client =
            _dbContext.Clients.Include(client => client.Clientorders)
                .SingleOrDefault(dto => dto.Clientid.Equals(clientId.Value.ToString()));
        if (client is null)
            return orders; //TODO: Przemyśleć czy nie exception

        foreach (var dto in client.Clientorders.ToList())
        {
            orders.Add(MapFromDto(dto));
        }

        return orders;
    }

    public ClientOrder? GetByOrderId(ClientOrderId orderId)
    {
        Clientorder? dto =
            _dbContext.Clientorders.SingleOrDefault(dto => dto.Orderid.Equals(orderId.Value.ToString()));
        if (dto is null)
            return null;
        return MapFromDto(dto);
    }

    public List<ClientOrder> GetByStatus(ClientOrderStatus status)
    {
        List<ClientOrder> clientOrders = new List<ClientOrder>();
        List<Clientorder> dtos = _dbContext.Clientorders.Where(dto => dto.Status.Equals(status.ToString()))
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
        List<Clientorder> dtos = _dbContext.Clientorders.ToList();
        foreach (var dto in dtos)
        {
            clientOrders.Add(MapFromDto(dto));
        }

        return clientOrders;
    }

    private Clientorder MapToDto(ClientOrder clientOrder)
    {
        Clientorder dto = new Clientorder
        {
            Orderid = clientOrder.Id.Value.ToString(),
            Addressdelivery = clientOrder.AddressDelivery,
            Addresssent = clientOrder.AddressSent,
            Clientid = clientOrder.ClientId.Value.ToString(),
            Datedelivered = clientOrder.DateOfExpectedDelivery,
            Datesent = clientOrder.DateOfExpectedSent,
            Sizeid = clientOrder.SizeId.Value.ToString(),
            Name = clientOrder.Name,
            Status = clientOrder.Status.ToString()
        };
        return dto;
    }

    private ClientOrder MapFromDto(Clientorder dto)
    {
        ClientOrder clientOrder = new ClientOrder(
            new ClientOrderId(Guid.Parse(dto.Orderid)),
            new PersonId(Guid.Parse(dto.Clientid)),
            dto.Datesent,
            dto.Datedelivered,
            dto.Addresssent,
            dto.Addressdelivery,
            dto.Name,
            new SizeId(Guid.Parse(dto.Sizeid)),
            Enum.Parse<ClientOrderStatus>(dto.Status));
        return clientOrder;
    }
}