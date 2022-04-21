using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class groupwaybillandmanifest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "GroupWayBill");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestRouteIdRouteId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_GroupWayBillId",
                table: "Manifest",
                column: "GroupWayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_ManifestRouteIdRouteId",
                table: "Manifest",
                column: "ManifestRouteIdRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBill_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                column: "GroupWayBillRouteIdRouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill",
                column: "GroupWayBillRouteIdRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_Route_ManifestRouteIdRouteId",
                table: "Manifest",
                column: "ManifestRouteIdRouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Route_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_Route_ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_GroupWayBillRouteIdRouteId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "ManifestRouteIdRouteId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "GroupWayBillRouteIdRouteId",
                table: "GroupWayBill");

            migrationBuilder.AlterColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
