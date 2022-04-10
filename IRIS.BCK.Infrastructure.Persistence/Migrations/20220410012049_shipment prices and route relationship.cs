using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class shipmentpricesandrouterelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "WalletNumberId",
                table: "WalletNumber",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PriceEnt_Route_RouteId",
                table: "PriceEnt");

            migrationBuilder.DropIndex(
                name: "IX_PriceEnt_RouteId",
                table: "PriceEnt");

            migrationBuilder.DropColumn(
                name: "WalletNumberId",
                table: "WalletNumber");

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
    }
}
