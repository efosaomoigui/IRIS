using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class fixedrelationshipmap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fleet_Trips_TripsId",
                table: "Fleet");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Manifest_ManifestId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_Trips_TripsId",
                table: "Manifest");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropTable(
                name: "GroupWayBillServiceCenter");

            migrationBuilder.DropTable(
                name: "ManifestServiceCenter");

            migrationBuilder.DropTable(
                name: "ServiceCenterShipment");

            migrationBuilder.DropTable(
                name: "ServiceCenter");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_TripsId",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_ManifestId",
                table: "GroupWayBill");

            migrationBuilder.DropIndex(
                name: "IX_Fleet_TripsId",
                table: "Fleet");

            migrationBuilder.DropColumn(
                name: "FuelCosts",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "FuelUsed",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "ManifestId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Miscelleneous",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "AvailableAtTerminal",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "AvailableOnline",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "CaptainFee",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DispatchFee",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "IsSubRoute",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "LoaderFee",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "MainRouteId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "RouteType",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "TripsId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "ManifestId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "TripsId",
                table: "Fleet");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "GroupWayBill",
                newName: "ServiceCenterId");

            migrationBuilder.AddColumn<Guid>(
                name: "FleetId",
                table: "Trips",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceCenterId",
                table: "Shipment",
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
                name: "ServiceCenterId",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "ServiceCenterId",
                table: "GroupWayBill",
                newName: "ShipmentId");

            migrationBuilder.AddColumn<decimal>(
                name: "FuelCosts",
                table: "Trips",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FuelUsed",
                table: "Trips",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ManifestId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Miscelleneous",
                table: "Trips",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableAtTerminal",
                table: "Route",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AvailableOnline",
                table: "Route",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "CaptainFee",
                table: "Route",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DispatchFee",
                table: "Route",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "IsSubRoute",
                table: "Route",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LoaderFee",
                table: "Route",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "MainRouteId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteType",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TripsId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TripsId",
                table: "Fleet",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceCenter",
                columns: table => new
                {
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCenterCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenter", x => x.ServiceCenterId);
                });

            migrationBuilder.CreateTable(
                name: "GroupWayBillServiceCenter",
                columns: table => new
                {
                    MyPropertyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupWayBillServiceCenter", x => new { x.MyPropertyId, x.ServiceCenterId });
                    table.ForeignKey(
                        name: "FK_GroupWayBillServiceCenter_GroupWayBill_MyPropertyId",
                        column: x => x.MyPropertyId,
                        principalTable: "GroupWayBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupWayBillServiceCenter_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManifestServiceCenter",
                columns: table => new
                {
                    ManifestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestServiceCenter", x => new { x.ManifestId, x.ServiceCenterId });
                    table.ForeignKey(
                        name: "FK_ManifestServiceCenter_Manifest_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManifestServiceCenter_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCenterShipment",
                columns: table => new
                {
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenterShipment", x => new { x.ServiceCenterId, x.ShipmentId });
                    table.ForeignKey(
                        name: "FK_ServiceCenterShipment_ServiceCenter_ServiceCenterId",
                        column: x => x.ServiceCenterId,
                        principalTable: "ServiceCenter",
                        principalColumn: "ServiceCenterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCenterShipment_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_TripsId",
                table: "Manifest",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBill_ManifestId",
                table: "GroupWayBill",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_Fleet_TripsId",
                table: "Fleet",
                column: "TripsId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBillServiceCenter_ServiceCenterId",
                table: "GroupWayBillServiceCenter",
                column: "ServiceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ManifestServiceCenter_ServiceCenterId",
                table: "ManifestServiceCenter",
                column: "ServiceCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenterShipment_ShipmentId",
                table: "ServiceCenterShipment",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fleet_Trips_TripsId",
                table: "Fleet",
                column: "TripsId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Manifest_ManifestId",
                table: "GroupWayBill",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_Trips_TripsId",
                table: "Manifest",
                column: "TripsId",
                principalTable: "Trips",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
