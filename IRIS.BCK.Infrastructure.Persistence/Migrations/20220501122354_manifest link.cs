using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class manifestlink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ManifestId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_ManifestId",
                table: "Trips",
                column: "ManifestId");

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
                name: "FK_Trips_Manifest_ManifestId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_ManifestId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ManifestId",
                table: "Trips");
        }
    }
}
