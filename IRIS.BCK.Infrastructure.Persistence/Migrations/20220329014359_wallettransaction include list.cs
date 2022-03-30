using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class wallettransactionincludelist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WalletNumberId",
                table: "WalletTransaction",
                type: "uniqueidentifier",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
