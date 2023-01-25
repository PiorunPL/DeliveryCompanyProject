using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class FacilityDto
{
    public string FacilityId { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CourierOrderDto> CourierOrderFacilityDeliveries { get; } = new List<CourierOrderDto>();

    public virtual ICollection<CourierOrderDto> CourierOrderFacilitySents { get; } = new List<CourierOrderDto>();

    public virtual ICollection<CourierDto> Couriers { get; } = new List<CourierDto>();
}
