using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class Facility
{
    public string Facilityid { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Courierorder> CourierorderFacilitydeliveries { get; } = new List<Courierorder>();

    public virtual ICollection<Courierorder> CourierorderFacilitysents { get; } = new List<Courierorder>();

    public virtual ICollection<Courier> Couriers { get; } = new List<Courier>();
}
