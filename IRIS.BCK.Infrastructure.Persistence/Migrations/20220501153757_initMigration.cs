using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripTrackId",
                table: "TrackHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripTrackId",
                table: "TrackHistory",
                newName: "TripsId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackHistory_TripTrackId",
                table: "TrackHistory",
                newName: "IX_TrackHistory_TripsId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackHistory_Trips_TripsId",
                table: "TrackHistory",
                column: "TripsId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripsId",
                table: "TrackHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.RenameColumn(
                name: "TripsId",
                table: "TrackHistory",
                newName: "TripTrackId");

            migrationBuilder.RenameIndex(
                name: "IX_TrackHistory_TripsId",
                table: "TrackHistory",
                newName: "IX_TrackHistory_TripTrackId");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TrackHistory_Trips_TripTrackId",
                table: "TrackHistory",
                column: "TripTrackId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
