using Microsoft.EntityFrameworkCore.Migrations;

namespace IRIS.BCK.Infrastructure.Persistence.Migrations
{
    public partial class UpdatedGroupWayBillManifestMapandShipmentGroupWayBillMapTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "ShipmentGroupWayBillMap",
                newName: "ShipmentGroupWayBillMapid");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "GroupWayBillManifestMap",
                newName: "GroupWayBillManifestMapid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShipmentGroupWayBillMapid",
                table: "ShipmentGroupWayBillMap",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GroupWayBillManifestMapid",
                table: "GroupWayBillManifestMap",
                newName: "id");
        }
    }
}
