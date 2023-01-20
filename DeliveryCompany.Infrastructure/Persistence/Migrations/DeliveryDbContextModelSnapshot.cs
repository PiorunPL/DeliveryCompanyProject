﻿// <auto-generated />
using System;
using DeliveryCompany.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DeliveryDbContext))]
    partial class DeliveryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Administrator", b =>
                {
                    b.Property<string>("Administratorid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("administratorid")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<DateTime>("Datebirth")
                        .HasColumnType("date")
                        .HasColumnName("datebirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password")
                        .HasComment("Saved as hash");

                    b.HasKey("Administratorid")
                        .HasName("PRIMARY");

                    b.ToTable("administrators", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Client", b =>
                {
                    b.Property<string>("Clientid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("clientid")
                        .IsFixedLength();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password")
                        .HasComment("Saved as Hash");

                    b.HasKey("Clientid")
                        .HasName("PRIMARY");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Clientorder", b =>
                {
                    b.Property<string>("Orderid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("orderid")
                        .IsFixedLength();

                    b.Property<string>("Addressdelivery")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("addressdelivery");

                    b.Property<string>("Addresssent")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("addresssent");

                    b.Property<string>("Clientid")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("clientid")
                        .IsFixedLength();

                    b.Property<DateTime>("Datedelivered")
                        .HasColumnType("date")
                        .HasColumnName("datedelivered");

                    b.Property<DateTime>("Datesent")
                        .HasColumnType("date")
                        .HasColumnName("datesent");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("Sizeid")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("sizeid")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("enum('New','Accepted','Cancelled','In Progress','Delivered')")
                        .HasColumnName("status")
                        .HasDefaultValueSql("'_utf8mb4\\\\''New\\\\'''");

                    b.HasKey("Orderid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Clientid" }, "fk_clientorders_clients");

                    b.HasIndex(new[] { "Sizeid" }, "fk_clientorders_sizes");

                    b.ToTable("clientorders", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Courier", b =>
                {
                    b.Property<string>("Courierid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("courierid")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<DateTime>("Datebirth")
                        .HasColumnType("date")
                        .HasColumnName("datebirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("firstname");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("lastname");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("password")
                        .HasComment("Saved as hash");

                    b.HasKey("Courierid")
                        .HasName("PRIMARY");

                    b.ToTable("couriers", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Courierorder", b =>
                {
                    b.Property<string>("Courierorderid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("courierorderid")
                        .IsFixedLength();

                    b.Property<string>("Courierid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("courierid")
                        .IsFixedLength();

                    b.Property<DateTime?>("Datedelivered")
                        .HasColumnType("date")
                        .HasColumnName("datedelivered");

                    b.Property<DateTime?>("Datesent")
                        .HasColumnType("date")
                        .HasColumnName("datesent");

                    b.Property<string>("Facilitydeliveryid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("facilitydeliveryid")
                        .IsFixedLength();

                    b.Property<string>("Facilitysentid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("facilitysentid")
                        .IsFixedLength();

                    b.Property<string>("Orderid")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("orderid")
                        .IsFixedLength();

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("enum('Hidden','Free','In progress','Delivered')")
                        .HasColumnName("status")
                        .HasDefaultValueSql("'_utf8mb4\\\\''Hidden\\\\'''");

                    b.HasKey("Courierorderid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Orderid" }, "fk_courierorders_clientorders");

                    b.HasIndex(new[] { "Courierid" }, "fk_courierorders_couriers");

                    b.HasIndex(new[] { "Facilitysentid" }, "fk_courierorders_facilities");

                    b.HasIndex(new[] { "Facilitydeliveryid" }, "fk_courierorders_facilities_0");

                    b.ToTable("courierorders", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Facility", b =>
                {
                    b.Property<string>("Facilityid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("facilityid")
                        .IsFixedLength();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Facilityid")
                        .HasName("PRIMARY");

                    b.ToTable("facilities", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Size", b =>
                {
                    b.Property<string>("Sizeid")
                        .HasMaxLength(38)
                        .HasColumnType("char(38)")
                        .HasColumnName("sizeid")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<double>("Price")
                        .HasColumnType("double")
                        .HasColumnName("price");

                    b.HasKey("Sizeid")
                        .HasName("PRIMARY");

                    b.ToTable("sizes", (string)null);
                });

            modelBuilder.Entity("Facilitiesassignment", b =>
                {
                    b.Property<string>("Facilityid")
                        .HasColumnType("char(38)");

                    b.Property<string>("Courierid")
                        .HasColumnType("char(38)");

                    b.HasKey("Facilityid", "Courierid")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Courierid" }, "fk_facilitiesassignments_courier");

                    b.ToTable("facilitiesassignments", (string)null);
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Clientorder", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Client", "Client")
                        .WithMany("Clientorders")
                        .HasForeignKey("Clientid")
                        .IsRequired()
                        .HasConstraintName("fk_clientorders_clients");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Size", "Size")
                        .WithMany("Clientorders")
                        .HasForeignKey("Sizeid")
                        .IsRequired()
                        .HasConstraintName("fk_clientorders_sizes");

                    b.Navigation("Client");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Courierorder", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Courier", "Courier")
                        .WithMany("Courierorders")
                        .HasForeignKey("Courierid")
                        .HasConstraintName("fk_courierorders_couriers");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Facility", "Facilitydelivery")
                        .WithMany("CourierorderFacilitydeliveries")
                        .HasForeignKey("Facilitydeliveryid")
                        .HasConstraintName("fk_courierorders_facilities_0");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Facility", "Facilitysent")
                        .WithMany("CourierorderFacilitysents")
                        .HasForeignKey("Facilitysentid")
                        .HasConstraintName("fk_courierorders_facilities");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Clientorder", "Order")
                        .WithMany("Courierorders")
                        .HasForeignKey("Orderid")
                        .IsRequired()
                        .HasConstraintName("fk_courierorders_clientorders");

                    b.Navigation("Courier");

                    b.Navigation("Facilitydelivery");

                    b.Navigation("Facilitysent");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Facilitiesassignment", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Courier", null)
                        .WithMany()
                        .HasForeignKey("Courierid")
                        .IsRequired()
                        .HasConstraintName("fk_facilitiesassignments_courier");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.Facility", null)
                        .WithMany()
                        .HasForeignKey("Facilityid")
                        .IsRequired()
                        .HasConstraintName("fk_facilitiesassignments_facilities");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Client", b =>
                {
                    b.Navigation("Clientorders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Clientorder", b =>
                {
                    b.Navigation("Courierorders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Courier", b =>
                {
                    b.Navigation("Courierorders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Facility", b =>
                {
                    b.Navigation("CourierorderFacilitydeliveries");

                    b.Navigation("CourierorderFacilitysents");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.Size", b =>
                {
                    b.Navigation("Clientorders");
                });
#pragma warning restore 612, 618
        }
    }
}
