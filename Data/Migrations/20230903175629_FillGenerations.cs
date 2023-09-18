using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillGenerations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Generations",
                columns: new[] { "Id", "ModelId", "Name" },
                values: new object[,]
                {
                    { 1, 7, "C7" },
                    { 2, 7, "C7 (FL)" },
                    { 3, 7, "C8" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
