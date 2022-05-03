using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWaybillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_GroupWaybillId",
                table: "Shipment",
                column: "GroupWaybillId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWaybillId",
                table: "Shipment",
                column: "GroupWaybillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWaybillId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_GroupWaybillId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "GroupWaybillId",
                table: "Shipment");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
