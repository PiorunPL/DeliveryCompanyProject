using System;
using System.Collections.Generic;
using DeliveryCompany.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeliveryCompany.Infrastructure.Context;

public partial class DeliveryDbContext : DbContext
{
    public DeliveryDbContext()
    {
    }

    public DeliveryDbContext(DbContextOptions<DeliveryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; } = null!;

    public virtual DbSet<Client> Clients { get; set; } = null!;

    public virtual DbSet<Clientorder> Clientorders { get; set; } = null!;

    public virtual DbSet<Courier> Couriers { get; set; } = null!;

    public virtual DbSet<Courierorder> Courierorders { get; set; } = null!;

    public virtual DbSet<Facility> Facilities { get; set; } = null!;

    public virtual DbSet<Size> Sizes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;Database=delivery_company_db;Uid=dbschema;Pwd=DbSchema@123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.Administratorid).HasName("PRIMARY");

            entity.ToTable("administrators");

            entity.Property(e => e.Administratorid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("administratorid");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Datebirth)
                .HasColumnType("date")
                .HasColumnName("datebirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasComment("Saved as hash")
                .HasColumnName("password");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("PRIMARY");

            entity.ToTable("clients");

            entity.Property(e => e.Clientid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("clientid");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasComment("Saved as Hash")
                .HasColumnName("password");
        });

        modelBuilder.Entity<Clientorder>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("PRIMARY");

            entity.ToTable("clientorders");

            entity.HasIndex(e => e.Clientid, "fk_clientorders_clients");

            entity.HasIndex(e => e.Sizeid, "fk_clientorders_sizes");

            entity.Property(e => e.Orderid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("orderid");
            entity.Property(e => e.Addressdelivery)
                .HasMaxLength(200)
                .HasColumnName("addressdelivery");
            entity.Property(e => e.Addresssent)
                .HasMaxLength(200)
                .HasColumnName("addresssent");
            entity.Property(e => e.Clientid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("clientid");
            entity.Property(e => e.Datedelivered)
                .HasColumnType("date")
                .HasColumnName("datedelivered");
            entity.Property(e => e.Datesent)
                .HasColumnType("date")
                .HasColumnName("datesent");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Sizeid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("sizeid");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'_utf8mb4\\\\''New\\\\'''")
                .HasColumnType("enum('New','Accepted','Cancelled','In Progress','Delivered')")
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientorders_clients");

            entity.HasOne(d => d.Size).WithMany(p => p.Clientorders)
                .HasForeignKey(d => d.Sizeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_clientorders_sizes");
        });

        modelBuilder.Entity<Courier>(entity =>
        {
            entity.HasKey(e => e.Courierid).HasName("PRIMARY");

            entity.ToTable("couriers");

            entity.Property(e => e.Courierid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("courierid");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Datebirth)
                .HasColumnType("date")
                .HasColumnName("datebirth");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasComment("Saved as hash")
                .HasColumnName("password");
        });

        modelBuilder.Entity<Courierorder>(entity =>
        {
            entity.HasKey(e => e.Courierorderid).HasName("PRIMARY");

            entity.ToTable("courierorders");

            entity.HasIndex(e => e.Orderid, "fk_courierorders_clientorders");

            entity.HasIndex(e => e.Courierid, "fk_courierorders_couriers");

            entity.HasIndex(e => e.Facilitysentid, "fk_courierorders_facilities");

            entity.HasIndex(e => e.Facilitydeliveryid, "fk_courierorders_facilities_0");

            entity.Property(e => e.Courierorderid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("courierorderid");
            entity.Property(e => e.Courierid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("courierid");
            entity.Property(e => e.Datedelivered)
                .HasColumnType("date")
                .HasColumnName("datedelivered");
            entity.Property(e => e.Datesent)
                .HasColumnType("date")
                .HasColumnName("datesent");
            entity.Property(e => e.Facilitydeliveryid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("facilitydeliveryid");
            entity.Property(e => e.Facilitysentid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("facilitysentid");
            entity.Property(e => e.Orderid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("orderid");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'_utf8mb4\\\\''Hidden\\\\'''")
                .HasColumnType("enum('Hidden','Free','In progress','Delivered')")
                .HasColumnName("status");

            entity.HasOne(d => d.Courier).WithMany(p => p.Courierorders)
                .HasForeignKey(d => d.Courierid)
                .HasConstraintName("fk_courierorders_couriers");

            entity.HasOne(d => d.Facilitydelivery).WithMany(p => p.CourierorderFacilitydeliveries)
                .HasForeignKey(d => d.Facilitydeliveryid)
                .HasConstraintName("fk_courierorders_facilities_0");

            entity.HasOne(d => d.Facilitysent).WithMany(p => p.CourierorderFacilitysents)
                .HasForeignKey(d => d.Facilitysentid)
                .HasConstraintName("fk_courierorders_facilities");

            entity.HasOne(d => d.Order).WithMany(p => p.Courierorders)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_courierorders_clientorders");
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.Facilityid).HasName("PRIMARY");

            entity.ToTable("facilities");

            entity.Property(e => e.Facilityid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("facilityid");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");

            entity.HasMany(d => d.Couriers).WithMany(p => p.Facilities)
                .UsingEntity<Dictionary<string, object>>(
                    "Facilitiesassignment",
                    r => r.HasOne<Courier>().WithMany()
                        .HasForeignKey("Courierid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_facilitiesassignments_courier"),
                    l => l.HasOne<Facility>().WithMany()
                        .HasForeignKey("Facilityid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_facilitiesassignments_facilities"),
                    j =>
                    {
                        j.HasKey("Facilityid", "Courierid").HasName("PRIMARY");
                        j.ToTable("facilitiesassignments");
                        j.HasIndex(new[] { "Courierid" }, "fk_facilitiesassignments_courier");
                    });
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.Sizeid).HasName("PRIMARY");

            entity.ToTable("sizes");

            entity.Property(e => e.Sizeid)
                .HasMaxLength(38)
                .IsFixedLength()
                .HasColumnName("sizeid");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
