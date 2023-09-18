using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCarEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Models_Motors_EngineId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncement_Models_ModelId",
                table: "SaleAnnouncement");

            migrationBuilder.DropIndex(
                name: "IX_Models_EngineId",
                table: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Generations_ModelId",
                table: "Generations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleAnnouncement",
                table: "SaleAnnouncement");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Generations");

            migrationBuilder.RenameTable(
                name: "SaleAnnouncement",
                newName: "SaleAnnouncements");

            migrationBuilder.RenameColumn(
                name: "ModelId",
                table: "SaleAnnouncements",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleAnnouncement_ModelId",
                table: "SaleAnnouncements",
                newName: "IX_SaleAnnouncements_CarId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleAnnouncements",
                table: "SaleAnnouncements",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    GenerationId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Generations_GenerationId",
                        column: x => x.GenerationId,
                        principalTable: "Generations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_Motors_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Motors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineModel",
                columns: table => new
                {
                    EnginesId = table.Column<int>(type: "int", nullable: false),
                    ModelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineModel", x => new { x.EnginesId, x.ModelsId });
                    table.ForeignKey(
                        name: "FK_EngineModel_Models_ModelsId",
                        column: x => x.ModelsId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineModel_Motors_EnginesId",
                        column: x => x.EnginesId,
                        principalTable: "Motors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelId",
                table: "Generations",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_EngineId",
                table: "Car",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_GenerationId",
                table: "Car",
                column: "GenerationId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineModel_ModelsId",
                table: "EngineModel",
                column: "ModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Car_CarId",
                table: "SaleAnnouncements",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Car_CarId",
                table: "SaleAnnouncements");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "EngineModel");

            migrationBuilder.DropIndex(
                name: "IX_Generations_ModelId",
                table: "Generations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SaleAnnouncements",
                table: "SaleAnnouncements");

            migrationBuilder.RenameTable(
                name: "SaleAnnouncements",
                newName: "SaleAnnouncement");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "SaleAnnouncement",
                newName: "ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_SaleAnnouncements_CarId",
                table: "SaleAnnouncement",
                newName: "IX_SaleAnnouncement_ModelId");

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Generations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SaleAnnouncement",
                table: "SaleAnnouncement",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Models_EngineId",
                table: "Models",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Generations_ModelId",
                table: "Generations",
                column: "ModelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Motors_EngineId",
                table: "Models",
                column: "EngineId",
                principalTable: "Motors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncement_Models_ModelId",
                table: "SaleAnnouncement",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
