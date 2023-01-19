using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.Migrations
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
                name: "administrators",
                columns: table => new
                {
                    administratorid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Saved as hash"),
                    datebirth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.administratorid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    clientid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Saved as Hash")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.clientid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "couriers",
                columns: table => new
                {
                    courierid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    firstname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Saved as hash"),
                    datebirth = table.Column<DateTime>(type: "date", nullable: false),
                    address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.courierid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facilities",
                columns: table => new
                {
                    facilityid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    address = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.facilityid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "sizes",
                columns: table => new
                {
                    sizeid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    price = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.sizeid);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "facilitiesassignments",
                columns: table => new
                {
                    Facilityid = table.Column<string>(type: "char(38)", nullable: false),
                    Courierid = table.Column<string>(type: "char(38)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.Facilityid, x.Courierid });
                    table.ForeignKey(
                        name: "fk_facilitiesassignments_courier",
                        column: x => x.Courierid,
                        principalTable: "couriers",
                        principalColumn: "courierid");
                    table.ForeignKey(
                        name: "fk_facilitiesassignments_facilities",
                        column: x => x.Facilityid,
                        principalTable: "facilities",
                        principalColumn: "facilityid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "clientorders",
                columns: table => new
                {
                    orderid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    clientid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    datesent = table.Column<DateTime>(type: "date", nullable: false),
                    datedelivered = table.Column<DateTime>(type: "date", nullable: true),
                    addresssent = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    addressdelivery = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    sizeid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    status = table.Column<string>(type: "enum('New','Accepted','Cancelled','In Progress','Delivered')", nullable: false, defaultValueSql: "'_utf8mb4\\\\''New\\\\'''")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.orderid);
                    table.ForeignKey(
                        name: "fk_clientorders_clients",
                        column: x => x.clientid,
                        principalTable: "clients",
                        principalColumn: "clientid");
                    table.ForeignKey(
                        name: "fk_clientorders_sizes",
                        column: x => x.sizeid,
                        principalTable: "sizes",
                        principalColumn: "sizeid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "courierorders",
                columns: table => new
                {
                    courierorderid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    orderid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: false),
                    datesent = table.Column<DateTime>(type: "date", nullable: true),
                    datedelivered = table.Column<DateTime>(type: "date", nullable: true),
                    facilitysentid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: true),
                    facilitydeliveryid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: true),
                    status = table.Column<string>(type: "enum('Hidden','Free','In progress','Delivered')", nullable: true, defaultValueSql: "'_utf8mb4\\\\''Hidden\\\\'''"),
                    courierid = table.Column<string>(type: "char(38)", fixedLength: true, maxLength: 38, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.courierorderid);
                    table.ForeignKey(
                        name: "fk_courierorders_clientorders",
                        column: x => x.orderid,
                        principalTable: "clientorders",
                        principalColumn: "orderid");
                    table.ForeignKey(
                        name: "fk_courierorders_couriers",
                        column: x => x.courierid,
                        principalTable: "couriers",
                        principalColumn: "courierid");
                    table.ForeignKey(
                        name: "fk_courierorders_facilities",
                        column: x => x.facilitysentid,
                        principalTable: "facilities",
                        principalColumn: "facilityid");
                    table.ForeignKey(
                        name: "fk_courierorders_facilities_0",
                        column: x => x.facilitydeliveryid,
                        principalTable: "facilities",
                        principalColumn: "facilityid");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "fk_clientorders_clients",
                table: "clientorders",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "fk_clientorders_sizes",
                table: "clientorders",
                column: "sizeid");

            migrationBuilder.CreateIndex(
                name: "fk_courierorders_clientorders",
                table: "courierorders",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "fk_courierorders_couriers",
                table: "courierorders",
                column: "courierid");

            migrationBuilder.CreateIndex(
                name: "fk_courierorders_facilities",
                table: "courierorders",
                column: "facilitysentid");

            migrationBuilder.CreateIndex(
                name: "fk_courierorders_facilities_0",
                table: "courierorders",
                column: "facilitydeliveryid");

            migrationBuilder.CreateIndex(
                name: "fk_facilitiesassignments_courier",
                table: "facilitiesassignments",
                column: "Courierid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "courierorders");

            migrationBuilder.DropTable(
                name: "facilitiesassignments");

            migrationBuilder.DropTable(
                name: "clientorders");

            migrationBuilder.DropTable(
                name: "couriers");

            migrationBuilder.DropTable(
                name: "facilities");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "sizes");
        }
    }
}
