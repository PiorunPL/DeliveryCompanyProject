using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class Courierorder
{
    public string Courierorderid { get; set; } = null!;

    public string Orderid { get; set; } = null!;

    public DateTime? Datesent { get; set; }

    public DateTime? Datedelivered { get; set; }

    public string? Facilitysentid { get; set; }

    public string? Facilitydeliveryid { get; set; }

    public string Status { get; set; } = null!;

    public string? Courierid { get; set; }

    public virtual Courier? Courier { get; set; }

    public virtual Facility? Facilitydelivery { get; set; }

    public virtual Facility? Facilitysent { get; set; }

    public virtual Clientorder Order { get; set; } = null!;
}
