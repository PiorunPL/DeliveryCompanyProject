namespace DeliveryCompany.Infrastructure.Persistence.Entities_BackUp;

public partial class Courier
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

    public virtual ICollection<Courierorder> Courierorders { get; } = new List<Courierorder>();

    public virtual ICollection<Facility> Facilities { get; } = new List<Facility>();
}
