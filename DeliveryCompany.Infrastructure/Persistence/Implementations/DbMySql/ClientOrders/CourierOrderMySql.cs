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
    private readonly DeliveryDbContext _dbContext;

    public CourierOrderMySql(DeliveryDbContext dbContext)
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
        _dbContext.Courierorders.Update(MapToDto(courierOrder, clientOrderId));
    }

    public List<CourierOrder> GetByClientOrderId(ClientOrderId clientOrderId)
    {
        List<CourierOrder> courierOrders = new List<CourierOrder>();
        var dtos = _dbContext.Courierorders.Where(dto=> dto.Orderid.Equals(clientOrderId.Value.ToString())).ToList();
        foreach (var dto in dtos)
        {
            courierOrders.Add(MapFromDto(dto));
        }

        return courierOrders;
    }

    public (CourierOrder?, ClientOrderId?) GetByCourierOrderId(CourierOrderId courierOrderId)
    {
        Entities.Courierorder? dto =
            _dbContext.Courierorders.SingleOrDefault(dto => dto.Courierorderid.Equals(courierOrderId.Value.ToString()));
        if (dto is null)
            return (null, null);
        return (MapFromDto(dto), new ClientOrderId(Guid.Parse(dto.Orderid)));
    }

    private Entities.Courierorder MapToDto(CourierOrder courierOrder, ClientOrderId clientOrderId)
    {
        Entities.Courierorder dto = new Courierorder
        {
            Courierid = courierOrder.CourierId?.Value.ToString(),
            Courierorderid = courierOrder.Id.Value.ToString(),
            Facilitydeliveryid = courierOrder.FacilityDeliveryId?.Value.ToString(),
            Facilitysentid = courierOrder.FacilitySentId?.Value.ToString(),
            Datedelivered = courierOrder.DateDelivered,
            Datesent = courierOrder.DateSent,
            Orderid = clientOrderId.Value.ToString(),
            Status = courierOrder.Status.ToString()
        };
        return dto;
    }

    private CourierOrder MapFromDto(Entities.Courierorder dto)
    {
        CourierOrder courierOrder = new CourierOrder(
            new CourierOrderId(Guid.Parse(dto.Courierorderid)),
            dto.Datesent,
            dto.Datedelivered,
            dto.Facilitysentid is null ? null : new FacilityId(Guid.Parse(dto.Facilitysentid)),
            dto.Facilitydeliveryid is null ? null : new FacilityId(Guid.Parse(dto.Facilitydeliveryid)),
            Enum.Parse<CourierOrderStatus>(dto.Status),
            dto.Courierid is null ? null : new PersonId(Guid.Parse(dto.Courierid))
        );
        return courierOrder;
    }
}