using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class datetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13cdc19a-148c-489a-b268-17854279f049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd57fafb-42f8-4272-a5e4-7b112565bfae");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimme",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433e1036-dbdd-49d2-bcd0-2c5741646224", null, "Admin", "ADMIN" },
                    { "aea97cb7-5138-4ea8-8a76-9caf94386b05", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "433e1036-dbdd-49d2-bcd0-2c5741646224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea97cb7-5138-4ea8-8a76-9caf94386b05");

            migrationBuilder.DropColumn(
                name: "DateTimme",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13cdc19a-148c-489a-b268-17854279f049", null, "User", "USER" },
                    { "bd57fafb-42f8-4272-a5e4-7b112565bfae", null, "Admin", "ADMIN" }
                });
        }
    }
}
