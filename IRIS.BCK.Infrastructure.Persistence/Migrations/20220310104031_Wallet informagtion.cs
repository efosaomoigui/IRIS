using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class Walletinformagtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TrackHistory_Trips_TripId1",
                table: "TrackHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Fleet_FleetId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_FleetId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_TrackHistory_TripId1",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "WalletTransaction");

            migrationBuilder.DropColumn(
                name: "WalletNumber",
                table: "WalletTransaction");

            migrationBuilder.DropColumn(
                name: "DriverDispatchFee",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FleetId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "TripId1",
                table: "TrackHistory");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "WalletTransaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "TripReference",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "TrackHistory",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ActionTimeStamp",
                table: "TrackHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TripReference",
                table: "TrackHistory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleet_Trips_TripsId",
                table: "Fleet");

            migrationBuilder.DropIndex(
                name: "IX_Fleet_TripsId",
                table: "Fleet");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "WalletTransaction");

            migrationBuilder.DropColumn(
                name: "ActionTimeStamp",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "TripReference",
                table: "TrackHistory");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "TripsId",
                table: "Fleet");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "WalletTransaction",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "WalletNumber",
                table: "WalletTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "TripReference",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DriverDispatchFee",
                table: "Trips",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "FleetId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Trips",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Location",
                table: "TrackHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeStamp",
                table: "TrackHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "TrackHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TripId1",
                table: "TrackHistory",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FleetId",
                table: "Trips",
                column: "FleetId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Fleet_FleetId",
                table: "Trips",
                column: "FleetId",
                principalTable: "Fleet",
                principalColumn: "FleetId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
