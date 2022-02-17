using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentandpayment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "waybill",
                table: "Shipment",
                newName: "Waybill");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Shipment",
                newName: "Reciever");

            migrationBuilder.RenameColumn(
                name: "ChassisNumber",
                table: "Fleet",
                newName: "ChasisNumber");

            migrationBuilder.AddColumn<Guid>(
                name: "ShipmentId",
                table: "Shipment",
                type: "uniqueidentifier",
                maxLength: 100,
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Shipment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Customer",
                table: "Shipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "DeclarationOfValueCheck",
                table: "Shipment",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DimensionUnit",
                table: "Shipment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Shipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsWeightEstimated",
                table: "Shipment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsdeclaredVal",
                table: "Shipment",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "ItemsWeight",
                table: "Shipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PickupOptions",
                table: "Shipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "breadth",
                table: "Shipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "length",
                table: "Shipment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<Guid>(
                name: "RouteId",
                table: "Route",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment",
                column: "ShipmentId");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    User = table.Column<int>(type: "int", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId2 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Address_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Address_Shipment_ShipmentId2",
                        column: x => x.ShipmentId2,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CollectionCenter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionStatus = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionCenter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CollectionCenter_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceEnt",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceEnt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceEnt_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShipmentItem",
                columns: table => new
                {
                    ShipmentItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentItem", x => x.ShipmentItemId);
                    table.ForeignKey(
                        name: "FK_ShipmentItem_Shipment_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipment",
                        principalColumn: "ShipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentId",
                table: "Address",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ShipmentId2",
                table: "Address",
                column: "ShipmentId2");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionCenter_ShipmentId",
                table: "CollectionCenter",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ShipmentId",
                table: "Payment",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceEnt_RouteId",
                table: "PriceEnt",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentItem_ShipmentId",
                table: "ShipmentItem",
                column: "ShipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "CollectionCenter");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PriceEnt");

            migrationBuilder.DropTable(
                name: "ShipmentItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ShipmentId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "DeclarationOfValueCheck",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "DimensionUnit",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "IsWeightEstimated",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "IsdeclaredVal",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "ItemsWeight",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "PickupOptions",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "breadth",
                table: "Shipment");

            migrationBuilder.DropColumn(
                name: "length",
                table: "Shipment");

            migrationBuilder.RenameColumn(
                name: "Waybill",
                table: "Shipment",
                newName: "waybill");

            migrationBuilder.RenameColumn(
                name: "Reciever",
                table: "Shipment",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "ChasisNumber",
                table: "Fleet",
                newName: "ChassisNumber");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Shipment",
                type: "int",
                maxLength: 100,
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "RouteId",
                table: "Route",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shipment",
                table: "Shipment",
                column: "Id");
        }
    }
}
