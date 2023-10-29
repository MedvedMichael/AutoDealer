using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillGearbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Gearboxes",
                columns: new[] { "Id", "GearboxType", "Name" },
                values: new object[,]
                {
                    { 1, 3, "DSG DQ 250" },
                    { 2, 3, "DSG DQ 500" },
                    { 3, 3, "DSG DQ 381" },
                    { 4, 1, "ZF 8HP" }
                });

            migrationBuilder.InsertData(
                table: "EngineGearbox",
                columns: new[] { "EnginesId", "GearboxesId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineGearbox",
                keyColumns: new[] { "EnginesId", "GearboxesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "EngineGearbox",
                keyColumns: new[] { "EnginesId", "GearboxesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "EngineGearbox",
                keyColumns: new[] { "EnginesId", "GearboxesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Gearboxes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
