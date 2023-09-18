using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillEngines : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Motors",
                columns: new[] { "Id", "Capacity", "FuelType", "HorsePower" },
                values: new object[,]
                {
                    { 1, 3.0, 0, 333 },
                    { 2, 3.0, 1, 245 },
                    { 3, 2.0, 0, 252 }
                });
            migrationBuilder.RenameTable("Motors", null, "Engines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable("Engines", null, "Motors");
            migrationBuilder.DeleteData(
                table: "Motors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Motors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Motors",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
