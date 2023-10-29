using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AnnouncementRefactoring2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenerationId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_EngineId",
                table: "SaleAnnouncements",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_EquipmentId",
                table: "SaleAnnouncements",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_GenerationId",
                table: "SaleAnnouncements",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_ModelId",
                table: "SaleAnnouncements",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Engines_EngineId",
                table: "SaleAnnouncements",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Equipments_EquipmentId",
                table: "SaleAnnouncements",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Generations_GenerationId",
                table: "SaleAnnouncements",
                column: "GenerationId",
                principalTable: "Generations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Models_ModelId",
                table: "SaleAnnouncements",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Engines_EngineId",
                table: "SaleAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Equipments_EquipmentId",
                table: "SaleAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Generations_GenerationId",
                table: "SaleAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Models_ModelId",
                table: "SaleAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_EngineId",
                table: "SaleAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_EquipmentId",
                table: "SaleAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_GenerationId",
                table: "SaleAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_ModelId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "GenerationId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "SaleAnnouncements");
        }
    }
}
