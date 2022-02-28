using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class addmigrationsforchangesfromamakanew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripReference = table.Column<int>(type: "int", nullable: false),
                    RouteCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fleetid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FleetId = table.Column<int>(type: "int", nullable: true),
                    ManifestId = table.Column<int>(type: "int", nullable: false),
                    manifestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Driver = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dispatcher = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverDispatchFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Miscelleneous = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelCosts = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FuelUsed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Fleet_FleetId",
                        column: x => x.FleetId,
                        principalTable: "Fleet",
                        principalColumn: "FleetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Manifest_manifestId",
                        column: x => x.manifestId,
                        principalTable: "Manifest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrackHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    TripId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<int>(type: "int", nullable: false),
                    TimeStamp = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackHistory_Trips_TripId1",
                        column: x => x.TripId1,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrackHistory_TripId1",
                table: "TrackHistory",
                column: "TripId1");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_FleetId",
                table: "Trips",
                column: "FleetId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_manifestId",
                table: "Trips",
                column: "manifestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrackHistory");

            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
