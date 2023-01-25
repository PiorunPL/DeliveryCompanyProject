using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.NewMigrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: false),
                    Lastname = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Datebirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.AdministratorId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: false),
                    Lastname = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.ClientId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    CourierId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Firstname = table.Column<string>(type: "longtext", nullable: false),
                    Lastname = table.Column<string>(type: "longtext", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false),
                    Datebirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CourierId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Address = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.FacilityId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    SizeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.SizeId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourierDtoFacilityDto",
                columns: table => new
                {
                    CouriersCourierId = table.Column<string>(type: "varchar(255)", nullable: false),
                    FacilitiesFacilityId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourierDtoFacilityDto", x => new { x.CouriersCourierId, x.FacilitiesFacilityId });
                    table.ForeignKey(
                        name: "FK_CourierDtoFacilityDto_Couriers_CouriersCourierId",
                        column: x => x.CouriersCourierId,
                        principalTable: "Couriers",
                        principalColumn: "CourierId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierDtoFacilityDto_Facilities_FacilitiesFacilityId",
                        column: x => x.FacilitiesFacilityId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ClientOrders",
                columns: table => new
                {
                    OrderId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateDelivered = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    AddressSent = table.Column<string>(type: "longtext", nullable: false),
                    AddressDelivery = table.Column<string>(type: "longtext", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    SizeId = table.Column<string>(type: "varchar(255)", nullable: false),
                    Status = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientOrders_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "SizeId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourierOrders",
                columns: table => new
                {
                    CourierOrderId = table.Column<string>(type: "varchar(255)", nullable: false),
                    OrderId = table.Column<string>(type: "varchar(255)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDelivered = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FacilitySentId = table.Column<string>(type: "varchar(255)", nullable: true),
                    FacilityDeliveryId = table.Column<string>(type: "varchar(255)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    CourierId = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.CourierOrderId);
                    table.ForeignKey(
                        name: "FK_CourierOrders_ClientOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ClientOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourierOrders_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "CourierId");
                    table.ForeignKey(
                        name: "FK_CourierOrders_Facilities_FacilityDeliveryId",
                        column: x => x.FacilityDeliveryId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId");
                    table.ForeignKey(
                        name: "FK_CourierOrders_Facilities_FacilitySentId",
                        column: x => x.FacilitySentId,
                        principalTable: "Facilities",
                        principalColumn: "FacilityId");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_ClientId",
                table: "ClientOrders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientOrders_SizeId",
                table: "ClientOrders",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierDtoFacilityDto_FacilitiesFacilityId",
                table: "CourierDtoFacilityDto",
                column: "FacilitiesFacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_CourierId",
                table: "CourierOrders",
                column: "CourierId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_FacilityDeliveryId",
                table: "CourierOrders",
                column: "FacilityDeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_FacilitySentId",
                table: "CourierOrders",
                column: "FacilitySentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourierOrders_OrderId",
                table: "CourierOrders",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "CourierDtoFacilityDto");

            migrationBuilder.DropTable(
                name: "CourierOrders");

            migrationBuilder.DropTable(
                name: "ClientOrders");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Sizes");
        }
    }
}
