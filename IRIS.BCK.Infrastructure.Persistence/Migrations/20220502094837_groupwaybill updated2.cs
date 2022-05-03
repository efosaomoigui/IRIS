using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillupdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWaybillId",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "GroupWaybillId",
                table: "Shipment",
                newName: "GroupWayBillId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_GroupWaybillId",
                table: "Shipment",
                newName: "IX_Shipment_GroupWayBillId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "GroupWayBillId",
                table: "Shipment",
                newName: "GroupWaybillId");

            migrationBuilder.RenameIndex(
                name: "IX_Shipment_GroupWayBillId",
                table: "Shipment",
                newName: "IX_Shipment_GroupWaybillId");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWaybillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWaybillId",
                table: "Shipment",
                column: "GroupWaybillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
