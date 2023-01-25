using System;
using System.Collections.Generic;
using DeliveryCompany.Infrastructure.Persistence.Entities_BackUp;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class FacilityDto
{
    public string Facilityid { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<CourierOrderDto> CourierorderFacilitydeliveries { get; } = new List<CourierOrderDto>();

    public virtual ICollection<CourierOrderDto> CourierorderFacilitysents { get; } = new List<CourierOrderDto>();

    public virtual ICollection<CourierDto> Couriers { get; } = new List<CourierDto>();
}
