using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Domain.Orders.Enitities;

public sealed class CourierOrder : Entity<CourierOrderId>
{
    public DateTime DateSent { get; set; }
    public DateTime DateDelivered { get; set; }
    public string AddressSent { get; set; }
    public string AddressDelivery { get; set; }
    public FacilityId FacilitySentId { get; set; }
    public FacilityId FacilityDeliveryId { get; set; }
    public CourierOrderStatus Status { get; set; }
    public PersonId CourierId { get; set; }

    private CourierOrder(
        CourierOrderId courierOrderId,
        DateTime dateSent,
        DateTime dateDelivered,
        string addressSent,
        string addressDelivery,
        FacilityId facilitySentId,
        FacilityId facilityDeliveryId,
        CourierOrderStatus status,
        PersonId courierId
    ) : base(courierOrderId)
    {
        DateSent = dateSent;
        DateDelivered = dateDelivered;
        AddressSent = addressSent;
        AddressDelivery = addressDelivery;
        FacilitySentId = facilitySentId;
        FacilityDeliveryId = facilityDeliveryId;
        Status = status;
        CourierId = courierId;
    }

    public static CourierOrder Create(
        DateTime dateSent,
        DateTime dateDelivered,
        string addressSent,
        string addressDelivery,
        FacilityId facilitySentId,
        FacilityId facilityDeliveryId,
        PersonId courierId)
    {
        return new(
            CourierOrderId.CreateUnique(),
            dateSent,
            dateDelivered,
            addressSent,
            addressDelivery,
            facilitySentId,
            facilityDeliveryId,
            CourierOrderStatus.Hidden,
            courierId
        );
    }
}