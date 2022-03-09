using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class UpdateManifestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WalletNumberId",
                table: "WalletNumber",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupWayBillId",
                table: "Manifest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupWayBillId",
                table: "Manifest");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WalletNumber",
                newName: "WalletNumberId");
        }
    }
}
