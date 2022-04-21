using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentRoute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRouteId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_RouteId",
                table: "Shipment",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_Route_RouteId",
                table: "Shipment",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_Route_RouteId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_RouteId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ShipmentRouteId",
                table: "Shipment");
        }
    }
}
