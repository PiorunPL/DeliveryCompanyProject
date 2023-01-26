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
    public DbSet<SharedOrderDto> SharedOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SharedOrderDto>()
            .HasKey(share => new { share.ClientOrderDtoId, share.ClientId });
            
        modelBuilder.Entity<CourierOrderDto>()
            .HasOne(p => p.FacilityDelivery)
            .WithMany(b => b.CourierOrderFacilityDeliveries)
            .HasForeignKey(cDto => cDto.FacilityDeliveryId);

        modelBuilder.Entity<AdministratorDto>()
            .HasKey(dto => dto.AdministratorId)
            .HasName("PRIMARY");

        modelBuilder.Entity<ClientDto>()
            .HasKey(dto => dto.ClientId)
            .HasName("PRIMARY");
        modelBuilder.Entity<ClientDto>()
            .HasMany(c => c.ClientOrders)
            .WithOne(o => o.Client);

        modelBuilder.Entity<ClientOrderDto>()
            .HasKey(dto => dto.OrderId)
            .HasName("PRIMARY");
        
        modelBuilder.Entity<CourierDto>()
            .HasKey(dto => dto.CourierId)
            .HasName("PRIMARY");
        
        modelBuilder.Entity<CourierOrderDto>()
            .HasKey(dto => dto.CourierOrderId)
            .HasName("PRIMARY");
        
        modelBuilder.Entity<FacilityDto>()
            .HasKey(dto => dto.FacilityId)
            .HasName("PRIMARY");
        
        modelBuilder.Entity<SizeDto>()
            .HasKey(dto => dto.SizeId)
            .HasName("PRIMARY");
        
        
    }
}