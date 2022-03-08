using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class updatedWalletEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripId1",
                table: "TrackHistory");

            migrationBuilder.DropIndex(
                name: "IX_TrackHistory_TripId1",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "TripId1",
                table: "TrackHistory");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WalletNumber",
                newName: "WalletNumberId");

            migrationBuilder.AlterColumn<Guid>(
                name: "TripId",
                table: "TrackHistory",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistory_TripId",
                table: "TrackHistory",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackHistory_Trips_TripId",
                table: "TrackHistory",
                column: "TripId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripId",
                table: "TrackHistory");

            migrationBuilder.DropIndex(
                name: "IX_TrackHistory_TripId",
                table: "TrackHistory");

            migrationBuilder.RenameColumn(
                name: "WalletNumberId",
                table: "WalletNumber",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TrackHistory",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "TripId1",
                table: "TrackHistory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistory_TripId1",
                table: "TrackHistory",
                column: "TripId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TrackHistory_Trips_TripId1",
                table: "TrackHistory",
                column: "TripId1",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
