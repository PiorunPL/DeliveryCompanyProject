using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.NewMigrations
{
    /// <inheritdoc />
    public partial class _005testRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeSalt",
                table: "Clients",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "HashedCode",
                table: "Clients",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeSalt",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "HashedCode",
                table: "Clients");
        }
    }
}
