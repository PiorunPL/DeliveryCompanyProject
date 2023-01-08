using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders;
using DeliveryCompany.Domain.Orders.Entities;
using DeliveryCompany.Domain.Orders.ValueObjects;
using DeliveryCompany.Infrastructure.Persistence.ClientOrders.Interfaces;

namespace DeliveryCompany.Infrastructure.Persistence.ClientOrders.Implementations;

public class CourierOrdersList : ICourierOrders
{
    private readonly List<CourierOrderDto> _courierOrdersDb = new List<CourierOrderDto>();

    public void Update(ClientOrder clientOrder)
    {
        List<CourierOrder> courierOrders = clientOrder.CourierOrders;

        _courierOrdersDb.RemoveAll(dto => dto.ClientOrderId.Equals(clientOrder.Id.Value.ToString()));

        foreach (CourierOrder courierOrder in courierOrders)
        {
            CourierOrderDto dto = MapToDto(courierOrder, clientOrder);
            _courierOrdersDb.Add(dto);
        }
    }

    public List<CourierOrder> GetByClientOrderId(ClientOrderId clientOrderId)
    {
        List<CourierOrderDto> dtos =
            _courierOrdersDb.FindAll(dto => dto.ClientOrderId.Equals(clientOrderId.Value.ToString()));
        List<CourierOrder> courierOrders = new List<CourierOrder>();

        foreach (CourierOrderDto dto in dtos)
        {
            CourierOrder courierOrder = MapFromDto(dto);
            courierOrders.Add(courierOrder);
        }

        return courierOrders;
    }

    public CourierOrder? GetByCourierOrderId(CourierOrderId courierOrderId)
    {
        CourierOrderDto? dto = _courierOrdersDb.FirstOrDefault();
        if (dto is null)
            return null;

        CourierOrder order = MapFromDto(dto);
        return order;
    }

    private CourierOrderDto MapToDto(CourierOrder courierOrder, ClientOrder clientOrder)
    {
        CourierOrderDto dto = new CourierOrderDto(
            courierOrder.Id.Value.ToString(),
            clientOrder.Id.Value.ToString(),
            courierOrder.DateSent,
            courierOrder.DateDelivered,
            courierOrder.FacilitySentId?.Value.ToString(),
            courierOrder.FacilityDeliveryId?.Value.ToString(),
            (int)courierOrder.Status,
            courierOrder.CourierId?.Value.ToString());

        return dto;
    }

    private CourierOrder MapFromDto(CourierOrderDto dto)
    {
        FacilityId? facilitySent = dto.FacilitySentId is null || dto.FacilitySentId.Equals("")
            ? null
            : new FacilityId(Guid.Parse(dto.FacilitySentId));

        FacilityId? facilityDelivered = dto.FacilityDeliveryId is null || dto.FacilityDeliveryId.Equals("")
            ? null
            : new FacilityId(Guid.Parse(dto.FacilityDeliveryId));

        PersonId? courierId = dto.CourierId is null || dto.CourierId.Equals("")
            ? null
            : new PersonId(Guid.Parse(dto.CourierId));

        CourierOrder courierOrder = new CourierOrder(
            new CourierOrderId(Guid.Parse(dto.Id)),
            dto.DateSent,
            dto.DateDelivered,
            facilitySent,
            facilityDelivered,
            (CourierOrderStatus)dto.Status,
            courierId);

        return courierOrder;
    }

    private class CourierOrderDto
    {
        public CourierOrderDto(string id, string clientOrderId, DateTime? dateSent, DateTime? dateDelivered,
            string? facilitySentId, string? facilityDeliveryId, int status, string? courierId)
        {
            Id = id;
            ClientOrderId = clientOrderId;
            DateSent = dateSent;
            DateDelivered = dateDelivered;
            FacilitySentId = facilitySentId;
            FacilityDeliveryId = facilityDeliveryId;
            Status = status;
            CourierId = courierId;
        }

        public string Id { get; set; }
        public string ClientOrderId { get; set; }
        public DateTime? DateSent { get; set; }
        public DateTime? DateDelivered { get; set; }
        public string? FacilitySentId { get; set; }
        public string? FacilityDeliveryId { get; set; }
        public int Status { get; set; }
        public string? CourierId { get; set; }
    }
}