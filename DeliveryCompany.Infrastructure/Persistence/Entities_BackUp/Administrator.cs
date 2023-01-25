namespace DeliveryCompany.Infrastructure.Persistence.Entities_BackUp;

public partial class Administrator
{
    public string Administratorid { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;

    /// <summary>
    /// Saved as hash
    /// </summary>
    public string Password { get; set; } = null!;

    public DateTime Datebirth { get; set; }

    public string Address { get; set; } = null!;
}
