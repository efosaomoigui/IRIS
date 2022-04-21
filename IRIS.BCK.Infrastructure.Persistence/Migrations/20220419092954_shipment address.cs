using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Shipment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RecieverAddress",
                table: "Shipment",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "RecieverAddress",
                table: "Shipment");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customershipmentAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    recievershipmentAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Shipment_customershipmentAddressId",
                        column: x => x.customershipmentAddressId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_Shipment_recievershipmentAddressId",
                        column: x => x.recievershipmentAddressId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_customershipmentAddressId",
                table: "Address",
                column: "customershipmentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_recievershipmentAddressId",
                table: "Address",
                column: "recievershipmentAddressId");
        }
    }
}
