using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class pricesettingsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceEnt_Route_RouteId",
                table: "PriceEnt");

            migrationBuilder.DropIndex(
                name: "IX_PriceEnt_RouteId",
                table: "PriceEnt");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoutePriceTbl");

            migrationBuilder.CreateIndex(
                name: "IX_PriceEnt_RouteId",
                table: "PriceEnt",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_PriceEnt_Route_RouteId",
                table: "PriceEnt",
                column: "RouteId",
                principalTable: "Route",
                principalColumn: "RouteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
