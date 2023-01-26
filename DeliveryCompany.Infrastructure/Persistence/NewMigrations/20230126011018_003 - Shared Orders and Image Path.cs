using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeliveryCompany.Infrastructure.Persistence.NewMigrations
{
    /// <inheritdoc />
    public partial class _003SharedOrdersandImagePath : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientOrderDtoOrderId",
                table: "Clients",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PathToImage",
                table: "ClientOrders",
                type: "longtext",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SharedOrders",
                columns: table => new
                {
                    ClientOrderDtoId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ClientId = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedOrders", x => new { x.ClientOrderDtoId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_SharedOrders_ClientOrders_ClientOrderDtoId",
                        column: x => x.ClientOrderDtoId,
                        principalTable: "ClientOrders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedOrders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientOrderDtoOrderId",
                table: "Clients",
                column: "ClientOrderDtoOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedOrders_ClientId",
                table: "SharedOrders",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientOrders_ClientOrderDtoOrderId",
                table: "Clients",
                column: "ClientOrderDtoOrderId",
                principalTable: "ClientOrders",
                principalColumn: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientOrders_ClientOrderDtoOrderId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "SharedOrders");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientOrderDtoOrderId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientOrderDtoOrderId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PathToImage",
                table: "ClientOrders");
        }
    }
}
