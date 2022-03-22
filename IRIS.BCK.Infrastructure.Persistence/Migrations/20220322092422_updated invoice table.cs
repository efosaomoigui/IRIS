using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class updatedinvoicetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Shipment_ShipmentId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ShipmentId",
                table: "Invoice");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Invoice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Invoice");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_ShipmentId",
                table: "Invoice",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Shipment_ShipmentId",
                table: "Invoice",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
