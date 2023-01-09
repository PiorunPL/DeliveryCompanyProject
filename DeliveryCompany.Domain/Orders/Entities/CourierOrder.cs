using DeliveryCompany.Domain.Common.Models;
using DeliveryCompany.Domain.Common.ValueObjects;
using DeliveryCompany.Domain.Facilities.ValueObjects;
using DeliveryCompany.Domain.Orders.ValueObjects;

namespace DeliveryCompany.Domain.Orders.Entities;

public sealed class CourierOrder : Entity<CourierOrderId>
{
    public DateTime? DateSent { get; set; }
    public DateTime? DateDelivered { get; set; }
    public FacilityId? FacilitySentId { get; set; }
    public FacilityId? FacilityDeliveryId { get; set; }
    public CourierOrderStatus Status { get; set; }
    public PersonId? CourierId { get; set; }

    public CourierOrder(
        CourierOrderId courierOrderId,
        FacilityId? facilitySentId,
        FacilityId? facilityDeliveryId,
        CourierOrderStatus status
    ) : base(courierOrderId)
    {
        DateSent = null;
        DateDelivered = null;
        FacilitySentId = facilitySentId;
        FacilityDeliveryId = facilityDeliveryId;
        Status = status;
        CourierId = null;
    }

    public CourierOrder(CourierOrderId courierOrderId, DateTime? dateSent, DateTime? dateDelivered,
 FacilityId? facilitySentId, FacilityId? facilityDeliveredId, CourierOrderStatus status,
 PersonId? courierId) : base(courierOrderId)
    {
        DateSent = dateSent;
        DateDelivered = dateDelivered;
        FacilitySentId = facilitySentId;
        FacilityDeliveryId = facilityDeliveredId;
        Status = status;
        CourierId = courierId;
    }

    public static CourierOrder Create(
        FacilityId? facilitySentId,
        FacilityId? facilityDeliveryId)
    {
        return new(
            CourierOrderId.CreateUnique(),
            facilitySentId,
            facilityDeliveryId,
            CourierOrderStatus.Hidden
        );
    }

    private void LogCreateCourierOrder()
    {
        string log = "Courier order created:";
        log += $"\n\tCourier order ID: {Id.Value.ToString()}";
        log += $"\n\tDate of sent: {DateSent.ToString()}";
        log += $"\n\tDate of delivery: {DateDelivered.ToString()}";
        log += $"\n\tFacility ID sent from: {FacilitySentId?.Value.ToString()}";
        log += $"\n\tFacility ID to delivery: {FacilityDeliveryId?.Value.ToString()}";
        log += $"\n\tStatus of order: {Status}, {nameof(Status)}";
        log += $"\n\tCourier ID: {CourierId?.Value.ToString()}";

        Console.WriteLine(log);
    }
}