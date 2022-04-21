using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class invoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "Invoice",
                type: "uniqueidentifier",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Shipment_ShipmentId",
                table: "Invoice");

            migrationBuilder.DropIndex(
                name: "IX_Invoice_ShipmentId",
                table: "Invoice");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Invoice");
        }
    }
}
