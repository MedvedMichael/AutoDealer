using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFuelType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuelType",
                table: "Motors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Motors");
        }
    }
}
