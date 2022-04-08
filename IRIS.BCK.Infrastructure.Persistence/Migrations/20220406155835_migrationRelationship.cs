using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class migrationRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_WalletNumber_WalletNumberId",
                table: "WalletTransaction");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletNumberId",
                table: "WalletTransaction",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WalletTransaction_WalletNumber_WalletNumberId",
                table: "WalletTransaction",
                column: "WalletNumberId",
                principalTable: "WalletNumber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WalletTransaction_WalletNumber_WalletNumberId",
                table: "WalletTransaction");

            migrationBuilder.AlterColumn<Guid>(
                name: "WalletNumberId",
                table: "WalletTransaction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
