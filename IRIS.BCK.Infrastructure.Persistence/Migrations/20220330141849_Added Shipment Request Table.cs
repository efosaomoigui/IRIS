using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class AddedShipmentRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRequestShipmentId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentRequestShipmentId1",
                table: "Address",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShipmentRequest",
                columns: table => new
                {
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<int>(type: "int", nullable: false),
                    Waybill = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Customer = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false),
                    Reciever = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickupOptions = table.Column<int>(type: "int", nullable: false),
                    ServiceCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRequest", x => x.ShipmentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentRequestShipmentId",
                table: "Address",
                column: "ShipmentRequestShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentRequestShipmentId1",
                table: "Address",
                column: "ShipmentRequestShipmentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId",
                table: "Address",
                column: "ShipmentRequestShipmentId",
                principalTable: "ShipmentRequest",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId1",
                table: "Address",
                column: "ShipmentRequestShipmentId1",
                principalTable: "ShipmentRequest",
                principalColumn: "ShipmentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_ShipmentRequest_ShipmentRequestShipmentId1",
                table: "Address");

            migrationBuilder.DropTable(
                name: "ShipmentRequest");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_ShipmentRequestShipmentId1",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShipmentRequestShipmentId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "ShipmentRequestShipmentId1",
                table: "Address");
        }
    }
}
