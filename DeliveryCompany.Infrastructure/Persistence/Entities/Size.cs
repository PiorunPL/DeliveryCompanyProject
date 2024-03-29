﻿using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class Size
{
    public string Sizeid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public virtual ICollection<Clientorder> Clientorders { get; } = new List<Clientorder>();
}
