using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class walletnumberadditiononuserregistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_WalletNumber_WalletNumberId",
                table: "WalletTransaction");

            migrationBuilder.DropIndex(
                name: "IX_WalletTransaction_WalletNumberId",
                table: "WalletTransaction");

            migrationBuilder.DropColumn(
                name: "WalletNumberId",
                table: "WalletTransaction");

            migrationBuilder.AddColumn<decimal>(
                name: "WalletNumber",
                table: "WalletTransaction",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "WalletBalance",
                table: "WalletNumber",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WalletNumber",
                table: "WalletTransaction");

            migrationBuilder.AddColumn<Guid>(
                name: "WalletNumberId",
                table: "WalletTransaction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "WalletBalance",
                table: "WalletNumber",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.CreateIndex(
                name: "IX_WalletTransaction_WalletNumberId",
                table: "WalletTransaction",
                column: "WalletNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_WalletNumber_WalletNumberId",
                table: "WalletTransaction",
                column: "WalletNumberId",
                principalTable: "WalletNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
