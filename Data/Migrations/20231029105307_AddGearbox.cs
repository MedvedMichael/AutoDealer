using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddGearbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GearboxId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Gearboxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GearboxType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gearboxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EngineGearbox",
                columns: table => new
                {
                    EnginesId = table.Column<int>(type: "int", nullable: false),
                    GearboxesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineGearbox", x => new { x.EnginesId, x.GearboxesId });
                    table.ForeignKey(
                        name: "FK_EngineGearbox_Engines_EnginesId",
                        column: x => x.EnginesId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineGearbox_Gearboxes_GearboxesId",
                        column: x => x.GearboxesId,
                        principalTable: "Gearboxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_GearboxId",
                table: "SaleAnnouncements",
                column: "GearboxId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineGearbox_GearboxesId",
                table: "EngineGearbox",
                column: "GearboxesId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements",
                column: "GearboxId",
                principalTable: "Gearboxes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements");

            migrationBuilder.DropTable(
                name: "EngineGearbox");

            migrationBuilder.DropTable(
                name: "Gearboxes");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_GearboxId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "GearboxId",
                table: "SaleAnnouncements");
        }
    }
}
