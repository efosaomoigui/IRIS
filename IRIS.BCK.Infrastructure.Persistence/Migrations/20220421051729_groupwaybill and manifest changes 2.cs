using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillandmanifestchanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteRouteId",
                table: "GroupWayBill");

            migrationBuilder.RenameColumn(
                name: "GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                newName: "GroupRIdRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWayBill_GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                newName: "IX_GroupWayBill_GroupRIdRouteId");

            migrationBuilder.AddColumn<string>(
                name: "GroupWayBillCode",
                table: "Manifest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Route_GroupRIdRouteId",
                table: "GroupWayBill",
                column: "GroupRIdRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Route_GroupRIdRouteId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "GroupWayBillCode",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "RId",
                table: "GroupWayBill");

            migrationBuilder.RenameColumn(
                name: "GroupRIdRouteId",
                table: "GroupWayBill",
                newName: "GroupWayBillRouteRouteId");

            migrationBuilder.RenameIndex(
                name: "IX_GroupWayBill_GroupRIdRouteId",
                table: "GroupWayBill",
                newName: "IX_GroupWayBill_GroupWayBillRouteRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteRouteId",
                table: "GroupWayBill",
                column: "GroupWayBillRouteRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
