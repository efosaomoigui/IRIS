using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem");

            migrationBuilder.DropColumn(
                name: "DeclarationOfValueCheck",
                table: "ShipmentItem");

            migrationBuilder.DropColumn(
                name: "IsVolumnWeight",
                table: "ShipmentItem");

            migrationBuilder.DropColumn(
                name: "IsWeightEstimated",
                table: "ShipmentItem");

            migrationBuilder.DropColumn(
                name: "IsdeclaredVal",
                table: "ShipmentItem");

            migrationBuilder.RenameColumn(
                name: "ItemsWeight",
                table: "ShipmentItem",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "WalletNumber",
                table: "Invoice",
                newName: "WaybilNumber");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Address",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "ShipmentItem",
                newName: "ItemsWeight");

            migrationBuilder.RenameColumn(
                name: "WaybilNumber",
                table: "Invoice",
                newName: "WalletNumber");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Address",
                newName: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DeclarationOfValueCheck",
                table: "ShipmentItem",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsVolumnWeight",
                table: "ShipmentItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeightEstimated",
                table: "ShipmentItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsdeclaredVal",
                table: "ShipmentItem",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
