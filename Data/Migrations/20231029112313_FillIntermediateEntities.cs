using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillIntermediateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EngineModel",
                columns: new[] { "EnginesId", "ModelsId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentModel",
                columns: new[] { "EquipmentsId", "ModelsId" },
                values: new object[,]
                {
                    { 1, 7 },
                    { 2, 7 },
                    { 3, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EngineModel",
                keyColumns: new[] { "EnginesId", "ModelsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "EngineModel",
                keyColumns: new[] { "EnginesId", "ModelsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "EngineModel",
                keyColumns: new[] { "EnginesId", "ModelsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "EquipmentModel",
                keyColumns: new[] { "EquipmentsId", "ModelsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "EquipmentModel",
                keyColumns: new[] { "EquipmentsId", "ModelsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "EquipmentModel",
                keyColumns: new[] { "EquipmentsId", "ModelsId" },
                keyValues: new object[] { 3, 7 });
        }
    }
}
