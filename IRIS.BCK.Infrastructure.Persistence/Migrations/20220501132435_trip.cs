using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class trip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TripTrackId",
                table: "TrackHistory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistory_TripTrackId",
                table: "TrackHistory",
                column: "TripTrackId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripTrackId",
                table: "TrackHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_TrackHistory_TripTrackId",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "TripTrackId",
                table: "TrackHistory");

            migrationBuilder.AlterColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
