using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SaleAnnouncements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MileageThousands" },
                values: new object[] { new DateTime(2023, 10, 29, 13, 52, 38, 897, DateTimeKind.Local).AddTicks(5304), 100 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SaleAnnouncements",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "MileageThousands" },
                values: new object[] { new DateTime(2023, 10, 29, 13, 51, 37, 979, DateTimeKind.Local).AddTicks(6343), 100000 });
        }
    }
}
