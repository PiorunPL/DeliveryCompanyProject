using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class Client
{
    public string Clientid { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    /// <summary>
    /// Saved as Hash
    /// </summary>
    public string Password { get; set; } = null!;

    public virtual ICollection<Clientorder> Clientorders { get; } = new List<Clientorder>();
}
