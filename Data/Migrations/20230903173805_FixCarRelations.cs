using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCarRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Generations_GenerationId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Generations_GenerationId",
                table: "Car",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Motors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Generations_GenerationId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Generations_GenerationId",
                table: "Car",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Motors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
