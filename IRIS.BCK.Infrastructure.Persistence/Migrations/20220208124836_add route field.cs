using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class addroutefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartureCentreId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationCentreId",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "Departure",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Departure",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "DepartureCentreId",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DestinationCentreId",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
