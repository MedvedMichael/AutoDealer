using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Engines_EngineId",
                table: "SaleAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Equipments_EquipmentId",
                table: "SaleAnnouncements");

            migrationBuilder.DropForeignKey(
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements");

            migrationBuilder.AlterColumn<int>(
                name: "GenerationId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GearboxId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EngineId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SaleAnnouncements",
                columns: new[] { "Id", "City", "Color", "CreatedAt", "Description", "EngineId", "EquipmentId", "GearboxId", "GenerationId", "MileageThousands", "ModelId", "OwnersCount", "Price", "UserId", "WinNumber", "Year" },
                values: new object[] { 1, "Kyiv", "Blue", new DateTime(2023, 10, 29, 13, 51, 37, 979, DateTimeKind.Local).AddTicks(6343), "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla euismod, nisl vitae aliquam ultricies, nunc nisl ultricies", 1, 3, 3, 2, 100000, 7, 1, 35000, "b0d3634c-6328-4814-b095-a0078f357393", "12345678901234567", 2015 });

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Engines_EngineId",
                table: "SaleAnnouncements",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Equipments_EquipmentId",
                table: "SaleAnnouncements",
                column: "EquipmentId",
                principalTable: "Equipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements",
                column: "GearboxId",
                principalTable: "Gearboxes",
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
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements");

            migrationBuilder.DeleteData(
                table: "SaleAnnouncements",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "GenerationId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GearboxId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EngineId",
                table: "SaleAnnouncements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "FK_SaleAnnouncements_Gearboxes_GearboxId",
                table: "SaleAnnouncements",
                column: "GearboxId",
                principalTable: "Gearboxes",
                principalColumn: "Id");
        }
    }
}
