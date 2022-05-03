using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class fleetinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleet_Trips_TripsId",
                table: "Fleet");

            migrationBuilder.DropIndex(
                name: "IX_Fleet_TripsId",
                table: "Fleet");

            migrationBuilder.DropColumn(
                name: "TripsId",
                table: "Fleet");

            migrationBuilder.AddColumn<Guid>(
                name: "FleetId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ManifestCode",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RouteFleetId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FleetId",
                table: "Trips",
                column: "FleetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Fleet_FleetId",
                table: "Trips",
                column: "FleetId",
                principalTable: "Fleet",
                principalColumn: "FleetId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Fleet_FleetId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_FleetId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FleetId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ManifestCode",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "RouteFleetId",
                table: "Trips");

            migrationBuilder.AddColumn<Guid>(
                name: "TripsId",
                table: "Fleet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fleet_TripsId",
                table: "Fleet",
                column: "TripsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleet_Trips_TripsId",
                table: "Fleet",
                column: "TripsId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
