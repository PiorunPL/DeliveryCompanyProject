using DeliveryCompany.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Context;

public class NewDeliveryDbContext : DbContext
{
    private string _connectionString = "Server=localhost;Database=delivery_new_db;Uid=dbschema;Pwd=DbSchema@123";
    public DbSet<AdministratorDto> Administrators { get; set; }
    public DbSet<ClientDto> Clients { get; set; }
    public DbSet<ClientOrderDto> ClientOrders { get; set; }
    public DbSet<CourierDto> Couriers { get; set; }
    public DbSet<CourierOrderDto> CourierOrders { get; set; }
    public DbSet<FacilityDto> Facilities { get; set; }
    public DbSet<SizeDto> Sizes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourierOrderDto>()
            .HasOne(p => p.Facilitydelivery)
            .WithMany(b => b.CourierorderFacilitydeliveries);
    }
}