using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillandmanifestchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_Route_ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.RenameColumn(
                name: "GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                newName: "GroupWayBillRouteRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWayBill_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                newName: "IX_GroupWayBill_GroupWayBillRouteRouteId");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_RouteId",
                table: "Manifest",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                column: "GroupWayBillRouteRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_Route_RouteId",
                table: "Manifest",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteRouteId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_Route_RouteId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_RouteId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Manifest");

            migrationBuilder.RenameColumn(
                name: "GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                newName: "GroupWayBillRouteIdRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWayBill_GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                newName: "IX_GroupWayBill_GroupWayBillRouteIdRouteId");

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestRouteIdRouteId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_ManifestRouteIdRouteId",
                table: "Manifest",
                column: "ManifestRouteIdRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                column: "GroupWayBillRouteIdRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_Route_ManifestRouteIdRouteId",
                table: "Manifest",
                column: "ManifestRouteIdRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
