using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "courierorders",
                type: "enum('Hidden','Free','In progress','Delivered')",
                nullable: false,
                defaultValueSql: "'_utf8mb4\\\\''Hidden\\\\'''",
                oldClrType: typeof(string),
                oldType: "enum('Hidden','Free','In progress','Delivered')",
                oldNullable: true,
                oldDefaultValueSql: "'_utf8mb4\\\\''Hidden\\\\'''");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "clientorders",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datedelivered",
                table: "clientorders",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "status",
                table: "courierorders",
                type: "enum('Hidden','Free','In progress','Delivered')",
                nullable: true,
                defaultValueSql: "'_utf8mb4\\\\''Hidden\\\\'''",
                oldClrType: typeof(string),
                oldType: "enum('Hidden','Free','In progress','Delivered')",
                oldDefaultValueSql: "'_utf8mb4\\\\''Hidden\\\\'''");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "clientorders",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "datedelivered",
                table: "clientorders",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }
    }
}
