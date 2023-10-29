using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenerationYears : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "Generations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "Generations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndYear", "StartYear" },
                values: new object[] { 2014, 2010 });

            migrationBuilder.UpdateData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndYear", "StartYear" },
                values: new object[] { 2018, 2014 });

            migrationBuilder.UpdateData(
                table: "Generations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndYear", "StartYear" },
                values: new object[] { null, 2018 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "Generations");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "Generations");
        }
    }
}
