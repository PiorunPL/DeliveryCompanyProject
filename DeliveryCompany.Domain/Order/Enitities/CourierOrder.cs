using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Facility.ValueObjects;
using DeliveryCompany.Domain.Order.ValueObjects;

namespace DeliveryCompany.Domain.Order.Enitities;

public sealed class CourierOrder : Entity<CourierOrderId>
{
    public ClientOrderId ClientOrderId { get; set; }
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
        ClientOrderId clientOrderId,
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
        ClientOrderId = clientOrderId;
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
        ClientOrderId clientOrderId,
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
            clientOrderId,
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