using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class SizeDto
{
    public string Sizeid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<ClientOrderDto> Clientorders { get; } = new List<ClientOrderDto>();
}
