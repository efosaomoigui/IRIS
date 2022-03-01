using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "ShipmentId2",
                table: "Address",
                newName: "ShipmentId1");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ShipmentId2",
                table: "Address",
                newName: "IX_Address_ShipmentId1");

            migrationBuilder.AddColumn<bool>(
                name: "IsVolumnWeight",
                table: "ShipmentItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId1",
                table: "Address",
                column: "ShipmentId1",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "IsVolumnWeight",
                table: "ShipmentItem");

            migrationBuilder.RenameColumn(
                name: "ShipmentId1",
                table: "Address",
                newName: "ShipmentId2");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ShipmentId1",
                table: "Address",
                newName: "IX_Address_ShipmentId2");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address",
                column: "ShipmentId2",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
