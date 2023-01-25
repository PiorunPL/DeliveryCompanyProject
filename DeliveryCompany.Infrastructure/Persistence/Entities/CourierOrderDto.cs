using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class CourierOrderDto
{
    public string CourierOrderId { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public DateTime? DateSent { get; set; }

    public DateTime? DateDelivered { get; set; }

    public string? FacilitySentId { get; set; }

    public string? FacilityDeliveryId { get; set; }

    public string Status { get; set; } = null!;

    public string? CourierId { get; set; }

    public virtual CourierDto? Courier { get; set; }

    public virtual FacilityDto? FacilityDelivery { get; set; }

    public virtual FacilityDto? FacilitySent { get; set; }

    public virtual ClientOrderDto Order { get; set; } = null!;
}
