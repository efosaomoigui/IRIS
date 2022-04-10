using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentprices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutePriceTbl");

            migrationBuilder.AddColumn<Guid>(
                name: "PriceId",
                table: "Route",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PricesId",
                table: "Route",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_PricesId",
                table: "Route",
                column: "PricesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_PriceEnt_PricesId",
                table: "Route",
                column: "PricesId",
                principalTable: "PriceEnt",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_PriceEnt_PricesId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_PricesId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "PriceId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "PricesId",
                table: "Route");

            migrationBuilder.CreateTable(
                name: "RoutePriceTbl",
                columns: table => new
                {
                    PriceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoutesRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutePriceTbl", x => new { x.PriceId, x.RoutesRouteId });
                    table.ForeignKey(
                        name: "FK_RoutePriceTbl_PriceEnt_PriceId",
                        column: x => x.PriceId,
                        principalTable: "PriceEnt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoutePriceTbl_Route_RoutesRouteId",
                        column: x => x.RoutesRouteId,
                        principalTable: "Route",
                        principalColumn: "RouteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoutePriceTbl_RoutesRouteId",
                table: "RoutePriceTbl",
                column: "RoutesRouteId");
        }
    }
}
