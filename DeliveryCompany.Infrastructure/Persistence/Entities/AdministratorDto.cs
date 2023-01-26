using System;
using System.Collections.Generic;

namespace DeliveryCompany.Infrastructure.Persistence.Entities;

public partial class AdministratorDto
{
    public string AdministratorId { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    /// <summary>
    /// Saved as hash
    /// </summary>
    public string Password { get; set; } = null!;
    
    public string Salt { get; set; } = null!;

    public DateTime Datebirth { get; set; }

    public string Address { get; set; } = null!;
}
