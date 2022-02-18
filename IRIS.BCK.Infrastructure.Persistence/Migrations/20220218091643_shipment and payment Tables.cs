using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentandpaymentTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeclarationOfValueCheck",
                table: "Shipment");

            migrationBuilder.AlterColumn<decimal>(
                name: "GrandTotal",
                table: "Shipment",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "GrandTotal",
                table: "Shipment",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<decimal>(
                name: "DeclarationOfValueCheck",
                table: "Shipment",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
