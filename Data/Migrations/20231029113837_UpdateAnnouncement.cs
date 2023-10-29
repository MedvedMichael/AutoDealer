using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "SaleAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SaleAnnouncements",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SaleAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WinNumber",
                table: "SaleAnnouncements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SaleAnnouncements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "WinNumber",
                table: "SaleAnnouncements");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SaleAnnouncements");
        }
    }
}
