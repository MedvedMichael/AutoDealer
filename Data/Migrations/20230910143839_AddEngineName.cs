using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddEngineName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineModel_Motors_EnginesId",
                table: "EngineModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Motors",
                table: "Motors");

            migrationBuilder.RenameTable(
                name: "Motors",
                newName: "Engines");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SaleAnnouncements",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Engines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Engines",
                table: "Engines",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "");

            migrationBuilder.UpdateData(
                table: "Engines",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "");

            migrationBuilder.CreateIndex(
                name: "IX_SaleAnnouncements_UserId",
                table: "SaleAnnouncements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Engines_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineModel_Engines_EnginesId",
                table: "EngineModel",
                column: "EnginesId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_AspNetUsers_UserId",
                table: "SaleAnnouncements",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Engines_EngineId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_EngineModel_Engines_EnginesId",
                table: "EngineModel");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_AspNetUsers_UserId",
                table: "SaleAnnouncements");

            migrationBuilder.DropIndex(
                name: "IX_SaleAnnouncements_UserId",
                table: "SaleAnnouncements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Engines",
                table: "Engines");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Engines");

            migrationBuilder.RenameTable(
                name: "Engines",
                newName: "Motors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Motors",
                table: "Motors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Motors_EngineId",
                table: "Car",
                column: "EngineId",
                principalTable: "Motors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineModel_Motors_EnginesId",
                table: "EngineModel",
                column: "EnginesId",
                principalTable: "Motors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
