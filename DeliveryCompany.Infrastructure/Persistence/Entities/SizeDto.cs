using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class SizeDto
{
    public string SizeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<ClientOrderDto> ClientOrders { get; } = new List<ClientOrderDto>();
}
