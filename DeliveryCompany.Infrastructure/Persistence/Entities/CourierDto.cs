using System;
using System.Collections.Generic;
using DeliveryCompany.Infrastructure.Persistence.Entities_BackUp;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class CourierDto
{
    public string Courierid { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    /// <summary>
    /// Saved as hash
    /// </summary>
    public string Password { get; set; } = null!;

    public DateTime Datebirth { get; set; }

    public string Address { get; set; } = null!;

    public virtual ICollection<CourierOrderDto> Courierorders { get; } = new List<CourierOrderDto>();

    public virtual ICollection<FacilityDto> Facilities { get; } = new List<FacilityDto>();
}
