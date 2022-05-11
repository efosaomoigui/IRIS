using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class tripmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripsId",
                table: "TrackHistory");

            migrationBuilder.DropIndex(
                name: "IX_TrackHistory_TripsId",
                table: "TrackHistory");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistory_TripsId",
                table: "TrackHistory",
                column: "TripsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackHistory_Trips_TripsId",
                table: "TrackHistory",
                column: "TripsId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
