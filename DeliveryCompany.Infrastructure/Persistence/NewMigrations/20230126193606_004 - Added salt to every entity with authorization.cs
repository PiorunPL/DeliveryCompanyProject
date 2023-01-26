using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.NewMigrations
{
    /// <inheritdoc />
    public partial class _004Addedsalttoeveryentitywithauthorization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Couriers",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Clients",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Administrators",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Couriers");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Administrators");
        }
    }
}
