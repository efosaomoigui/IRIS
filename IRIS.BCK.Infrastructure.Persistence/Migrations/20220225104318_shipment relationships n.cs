using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentrelationshipsn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId2",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentId2",
                table: "Address",
                column: "ShipmentId2");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address",
                column: "ShipmentId2",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentId2",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShipmentId2",
                table: "Address");
        }
    }
}
