using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Infrastructure.Context;
using DeliveryCompany.Infrastructure.Persistence.Common.ClientOrders.Interfaces;
using DeliveryCompany.Infrastructure.Persistence.Entities;

namespace DeliveryCompany.Infrastructure.Persistence.Implementations.DbMySql.ClientOrders;

public class CourierOrderMySql : ICourierOrders
{
    private readonly NewDeliveryDbContext _dbContext;

    public CourierOrderMySql(NewDeliveryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Update(ClientOrder clientOrder)
    {
        var courierOrders = clientOrder.CourierOrders;
        foreach (var courierOrder in courierOrders)
        {
            Update(courierOrder, clientOrder.Id);
        }

        _dbContext.SaveChanges();
    }

    private void Update(CourierOrder courierOrder, ClientOrderId clientOrderId)
    {
        _dbContext.CourierOrders.Update(MapToDto(courierOrder, clientOrderId));
    }

    public List<CourierOrder> GetByClientOrderId(ClientOrderId clientOrderId)
    {
        List<CourierOrder> courierOrders = new List<CourierOrder>();
        var dtos = _dbContext.CourierOrders.Where(dto=> dto.OrderId.Equals(clientOrderId.Value.ToString())).ToList();
        foreach (var dto in dtos)
        {
            courierOrders.Add(MapFromDto(dto));
        }

        return courierOrders;
    }

    public (CourierOrder?, ClientOrderId?) GetByCourierOrderId(CourierOrderId courierOrderId)
    {
        CourierOrderDto? dto =
            _dbContext.CourierOrders.SingleOrDefault(dto => dto.CourierOrderId.Equals(courierOrderId.Value.ToString()));
        if (dto is null)
            return (null, null);
        return (MapFromDto(dto), new ClientOrderId(Guid.Parse(dto.OrderId)));
    }

    private CourierOrderDto MapToDto(CourierOrder courierOrder, ClientOrderId clientOrderId)
    {
        CourierOrderDto dto = new CourierOrderDto
        {
            CourierId = courierOrder.CourierId?.Value.ToString(),
            CourierOrderId = courierOrder.Id.Value.ToString(),
            FacilityDeliveryId = courierOrder.FacilityDeliveryId?.Value.ToString(),
            FacilitySentId = courierOrder.FacilitySentId?.Value.ToString(),
            DateDelivered = courierOrder.DateDelivered,
            DateSent = courierOrder.DateSent,
            OrderId = clientOrderId.Value.ToString(),
            Status = courierOrder.Status.ToString()
        };
        return dto;
    }

    private CourierOrder MapFromDto(CourierOrderDto dto)
    {
        CourierOrder courierOrder = new CourierOrder(
            new CourierOrderId(Guid.Parse(dto.CourierOrderId)),
            dto.DateSent,
            dto.DateDelivered,
            dto.FacilitySentId is null ? null : new FacilityId(Guid.Parse(dto.FacilitySentId)),
            dto.FacilityDeliveryId is null ? null : new FacilityId(Guid.Parse(dto.FacilityDeliveryId)),
            Enum.Parse<CourierOrderStatus>(dto.Status),
            dto.CourierId is null ? null : new PersonId(Guid.Parse(dto.CourierId))
        );
        return courierOrder;
    }
}