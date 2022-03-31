using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentrequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId1",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentRequestShipmentId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "GrandTotal",
                table: "ShipmentRequest");

            migrationBuilder.DropColumn(
                name: "ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShipmentRequestShipmentId1",
                table: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "PickupOptions",
                table: "ShipmentRequest",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "ShipmentRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieverAddress",
                table: "ShipmentRequest",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "ShipmentRequest");

            migrationBuilder.DropColumn(
                name: "RecieverAddress",
                table: "ShipmentRequest");

            migrationBuilder.AlterColumn<int>(
                name: "PickupOptions",
                table: "ShipmentRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GrandTotal",
                table: "ShipmentRequest",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRequestShipmentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRequestShipmentId1",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentRequestShipmentId",
                table: "Address",
                column: "ShipmentRequestShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentRequestShipmentId1",
                table: "Address",
                column: "ShipmentRequestShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId",
                table: "Address",
                column: "ShipmentRequestShipmentId",
                principalTable: "ShipmentRequest",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId1",
                table: "Address",
                column: "ShipmentRequestShipmentId1",
                principalTable: "ShipmentRequest",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
