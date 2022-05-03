using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillupdated3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

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
    }
}
