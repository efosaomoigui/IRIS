using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class numbergenerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "WalletTransaction",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceCode",
                table: "ServiceCenter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NumberEnt",
                columns: table => new
                {
                    NumberEntId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServiceCentreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberGeneratorType = table.Column<int>(type: "int", nullable: false),
                    NumberCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberEnt", x => x.NumberEntId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NumberEnt");

            migrationBuilder.DropColumn(
                name: "ServiceCode",
                table: "ServiceCenter");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "WalletTransaction",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
