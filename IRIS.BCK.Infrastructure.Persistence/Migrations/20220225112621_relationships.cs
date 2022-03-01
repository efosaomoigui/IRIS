using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class relationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId1",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShipmentId1",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "ShipmentId2",
                table: "Address",
                newName: "CustomerAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ShipmentId2",
                table: "Address",
                newName: "IX_Address_CustomerAddressAddressId");

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipmentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAddress_Shipment_ShipmentId1",
                        column: x => x.ShipmentId1,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_ShipmentId",
                table: "CustomerAddress",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddress_ShipmentId1",
                table: "CustomerAddress",
                column: "ShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_CustomerAddress_CustomerAddressAddressId",
                table: "Address",
                column: "CustomerAddressAddressId",
                principalTable: "CustomerAddress",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_CustomerAddress_CustomerAddressAddressId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "CustomerAddressAddressId",
                table: "Address",
                newName: "ShipmentId2");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CustomerAddressAddressId",
                table: "Address",
                newName: "IX_Address_ShipmentId2");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId1",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentId1",
                table: "Address",
                column: "ShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId1",
                table: "Address",
                column: "ShipmentId1",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId2",
                table: "Address",
                column: "ShipmentId2",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
