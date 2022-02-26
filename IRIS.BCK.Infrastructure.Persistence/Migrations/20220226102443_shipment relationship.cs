using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_CustomerAddress_CustomerAddressAddressId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address");

            migrationBuilder.DropTable(
                name: "CustomerAddress");

            migrationBuilder.RenameColumn(
                name: "ShipmentId",
                table: "Address",
                newName: "recievershipmentAddressId");

            migrationBuilder.RenameColumn(
                name: "CustomerAddressAddressId",
                table: "Address",
                newName: "customershipmentAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_ShipmentId",
                table: "Address",
                newName: "IX_Address_recievershipmentAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_CustomerAddressAddressId",
                table: "Address",
                newName: "IX_Address_customershipmentAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_customershipmentAddressId",
                table: "Address",
                column: "customershipmentAddressId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_recievershipmentAddressId",
                table: "Address",
                column: "recievershipmentAddressId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_customershipmentAddressId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Shipment_recievershipmentAddressId",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "recievershipmentAddressId",
                table: "Address",
                newName: "ShipmentId");

            migrationBuilder.RenameColumn(
                name: "customershipmentAddressId",
                table: "Address",
                newName: "CustomerAddressAddressId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_recievershipmentAddressId",
                table: "Address",
                newName: "IX_Address_ShipmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_customershipmentAddressId",
                table: "Address",
                newName: "IX_Address_CustomerAddressAddressId");

            migrationBuilder.CreateTable(
                name: "CustomerAddress",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShipmentId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    User = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Shipment_ShipmentId",
                table: "Address",
                column: "ShipmentId",
                principalTable: "Shipment",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
