﻿// <auto-generated />
using System;
using DeliveryCompany.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.NewMigrations
{
    [DbContext(typeof(NewDeliveryDbContext))]
    partial class NewDeliveryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CourierDtoFacilityDto", b =>
                {
                    b.Property<string>("CouriersCourierId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FacilitiesFacilityId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("CouriersCourierId", "FacilitiesFacilityId");

                    b.HasIndex("FacilitiesFacilityId");

                    b.ToTable("CourierDtoFacilityDto");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.AdministratorDto", b =>
                {
                    b.Property<string>("AdministratorId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Datebirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("AdministratorId")
                        .HasName("PRIMARY");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.ClientDto", b =>
                {
                    b.Property<string>("ClientId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ClientId")
                        .HasName("PRIMARY");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.ClientOrderDto", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AddressDelivery")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AddressSent")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("DateDelivered")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateSent")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SizeId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("OrderId")
                        .HasName("PRIMARY");

                    b.HasIndex("ClientId");

                    b.HasIndex("SizeId");

                    b.ToTable("ClientOrders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.CourierDto", b =>
                {
                    b.Property<string>("CourierId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Datebirth")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CourierId")
                        .HasName("PRIMARY");

                    b.ToTable("Couriers");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.CourierOrderDto", b =>
                {
                    b.Property<string>("CourierOrderId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("CourierId")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("DateDelivered")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateSent")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FacilityDeliveryId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FacilitySentId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("OrderId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CourierOrderId")
                        .HasName("PRIMARY");

                    b.HasIndex("CourierId");

                    b.HasIndex("FacilityDeliveryId");

                    b.HasIndex("FacilitySentId");

                    b.HasIndex("OrderId");

                    b.ToTable("CourierOrders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.FacilityDto", b =>
                {
                    b.Property<string>("FacilityId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("FacilityId")
                        .HasName("PRIMARY");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.SizeDto", b =>
                {
                    b.Property<string>("SizeId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.HasKey("SizeId")
                        .HasName("PRIMARY");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("CourierDtoFacilityDto", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.CourierDto", null)
                        .WithMany()
                        .HasForeignKey("CouriersCourierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.FacilityDto", null)
                        .WithMany()
                        .HasForeignKey("FacilitiesFacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.ClientOrderDto", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.ClientDto", "Client")
                        .WithMany("ClientOrders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.SizeDto", "Size")
                        .WithMany("ClientOrders")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.CourierOrderDto", b =>
                {
                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.CourierDto", "Courier")
                        .WithMany("CourierOrders")
                        .HasForeignKey("CourierId");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.FacilityDto", "FacilityDelivery")
                        .WithMany("CourierOrderFacilityDeliveries")
                        .HasForeignKey("FacilityDeliveryId");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.FacilityDto", "FacilitySent")
                        .WithMany("CourierOrderFacilitySents")
                        .HasForeignKey("FacilitySentId");

                    b.HasOne("DeliveryCompany.Infrastructure.Persistence.Entities.ClientOrderDto", "Order")
                        .WithMany("CourierOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courier");

                    b.Navigation("FacilityDelivery");

                    b.Navigation("FacilitySent");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.ClientDto", b =>
                {
                    b.Navigation("ClientOrders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.ClientOrderDto", b =>
                {
                    b.Navigation("CourierOrders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.CourierDto", b =>
                {
                    b.Navigation("CourierOrders");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.FacilityDto", b =>
                {
                    b.Navigation("CourierOrderFacilityDeliveries");

                    b.Navigation("CourierOrderFacilitySents");
                });

            modelBuilder.Entity("DeliveryCompany.Infrastructure.Persistence.Entities.SizeDto", b =>
                {
                    b.Navigation("ClientOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
