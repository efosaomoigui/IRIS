using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
