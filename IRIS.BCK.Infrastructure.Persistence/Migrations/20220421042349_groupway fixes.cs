using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwayfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Waybill",
                table: "GroupWayBill",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBill_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "Waybill",
                table: "GroupWayBill");
        }
    }
}
