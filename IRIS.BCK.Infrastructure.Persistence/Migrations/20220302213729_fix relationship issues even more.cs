using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class fixrelationshipissuesevenmore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCenter_GroupWayBill_GroupWayBillId",
                table: "ServiceCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCenter_Manifest_ManifestId",
                table: "ServiceCenter");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCenter_GroupWayBillId",
                table: "ServiceCenter");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCenter_ManifestId",
                table: "ServiceCenter");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "ServiceCenter");

            migrationBuilder.DropColumn(
                name: "ManifestId",
                table: "ServiceCenter");

            migrationBuilder.AddColumn<Guid>(
                name: "ServiceCenterId",
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
                name: "ShipmentId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupWayBillServiceCenter");

            migrationBuilder.DropTable(
                name: "ManifestServiceCenter");

            migrationBuilder.DropTable(
                name: "ServiceCenterShipment");

            migrationBuilder.DropColumn(
                name: "ServiceCenterId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "ServiceCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestId",
                table: "ServiceCenter",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_GroupWayBillId",
                table: "ServiceCenter",
                column: "GroupWayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_ManifestId",
                table: "ServiceCenter",
                column: "ManifestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCenter_GroupWayBill_GroupWayBillId",
                table: "ServiceCenter",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCenter_Manifest_ManifestId",
                table: "ServiceCenter",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
