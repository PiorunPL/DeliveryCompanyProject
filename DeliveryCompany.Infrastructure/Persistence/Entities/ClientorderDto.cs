using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class ClientOrderDto
{
    public string Orderid { get; set; } = null!;

    public string Clientid { get; set; } = null!;

    public DateTime Datesent { get; set; }

    public DateTime Datedelivered { get; set; }

    public string Addresssent { get; set; } = null!;

    public string Addressdelivery { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Sizeid { get; set; } = null!;

    public string Status { get; set; } = null!;

    public virtual ClientDto Client { get; set; } = null!;

    public virtual ICollection<CourierOrderDto> Courierorders { get; } = new List<CourierOrderDto>();

    public virtual SizeDto Size { get; set; } = null!;
}
