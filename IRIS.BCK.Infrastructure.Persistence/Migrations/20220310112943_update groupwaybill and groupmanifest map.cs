using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class updategroupwaybillandgroupmanifestmap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupWayBillManifestMap",
                table: "ShipmentGroupWayBillMap",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TripId",
                table: "GroupWayBillManifestMap",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentGroupWayBillMap_GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap",
                column: "GroupWayBillManifestMapid");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBillManifestMap_TripId",
                table: "GroupWayBillManifestMap",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBillManifestMap_Trips_TripId",
                table: "GroupWayBillManifestMap",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentGroupWayBillMap_GroupWayBillManifestMap_GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap",
                column: "GroupWayBillManifestMapid",
                principalTable: "GroupWayBillManifestMap",
                principalColumn: "GroupWayBillManifestMapid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBillManifestMap_Trips_TripId",
                table: "GroupWayBillManifestMap");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentGroupWayBillMap_GroupWayBillManifestMap_GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap");

            migrationBuilder.DropIndex(
                name: "IX_ShipmentGroupWayBillMap_GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBillManifestMap_TripId",
                table: "GroupWayBillManifestMap");

            migrationBuilder.DropColumn(
                name: "GroupWayBillManifestMap",
                table: "ShipmentGroupWayBillMap");

            migrationBuilder.DropColumn(
                name: "GroupWayBillManifestMapid",
                table: "ShipmentGroupWayBillMap");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "GroupWayBillManifestMap");
        }
    }
}
