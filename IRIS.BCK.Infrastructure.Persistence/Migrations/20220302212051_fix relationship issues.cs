using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class fixrelationshipissues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId1",
                table: "Manifest");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem");

            migrationBuilder.DropIndex(
                name: "IX_Manifest_GroupWayBillId1",
                table: "Manifest");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId1",
                table: "Manifest");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "GroupWayBill");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ManifestId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceCenter",
                columns: table => new
                {
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCenterCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupWayBillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManifestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCenter", x => x.ServiceCenterId);
                    table.ForeignKey(
                        name: "FK_ServiceCenter_GroupWayBill_GroupWayBillId",
                        column: x => x.GroupWayBillId,
                        principalTable: "GroupWayBill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceCenter_Manifest_ManifestId",
                        column: x => x.ManifestId,
                        principalTable: "Manifest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipment_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBill_ManifestId",
                table: "GroupWayBill",
                column: "ManifestId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_GroupWayBillId",
                table: "ServiceCenter",
                column: "GroupWayBillId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCenter_ManifestId",
                table: "ServiceCenter",
                column: "ManifestId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Manifest_ManifestId",
                table: "GroupWayBill",
                column: "ManifestId",
                principalTable: "Manifest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment",
                column: "GroupWayBillId",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupWayBill_Manifest_ManifestId",
                table: "GroupWayBill");

            migrationBuilder.DropForeignKey(
                name: "FK_Shipment_GroupWayBill_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem");

            migrationBuilder.DropTable(
                name: "ServiceCenter");

            migrationBuilder.DropIndex(
                name: "IX_Shipment_GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropIndex(
                name: "IX_GroupWayBill_ManifestId",
                table: "GroupWayBill");

            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ManifestId",
                table: "GroupWayBill");

            migrationBuilder.AlterColumn<Guid>(
                name: "ShipmentId",
                table: "ShipmentItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId1",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "GroupWayBill",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Manifest_GroupWayBillId1",
                table: "Manifest",
                column: "GroupWayBillId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupWayBill_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupWayBill_Shipment_ShipmentId",
                table: "GroupWayBill",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Manifest_GroupWayBill_GroupWayBillId1",
                table: "Manifest",
                column: "GroupWayBillId1",
                principalTable: "GroupWayBill",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ShipmentItem_Shipment_ShipmentId",
                table: "ShipmentItem",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
