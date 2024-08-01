using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class BlogUserXref : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "433e1036-dbdd-49d2-bcd0-2c5741646224");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aea97cb7-5138-4ea8-8a76-9caf94386b05");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "AspNetUserRoles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "013aca60-1397-4291-9261-8e1433238400", null, new DateTime(2024, 7, 29, 19, 20, 13, 382, DateTimeKind.Utc).AddTicks(4970), "Roles", "ReadyOnly", "READONLY" },
                    { "2654beec-406a-4911-a71d-96db8223f8a8", null, new DateTime(2024, 7, 29, 19, 20, 13, 382, DateTimeKind.Utc).AddTicks(4960), "Roles", "Admin", "ADMIN" },
                    { "e776d52a-3de0-4f3e-a79b-fb8b3fcb6fdb", null, new DateTime(2024, 7, 29, 19, 20, 13, 382, DateTimeKind.Utc).AddTicks(4950), "Roles", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "013aca60-1397-4291-9261-8e1433238400");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2654beec-406a-4911-a71d-96db8223f8a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e776d52a-3de0-4f3e-a79b-fb8b3fcb6fdb");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433e1036-dbdd-49d2-bcd0-2c5741646224", null, "Admin", "ADMIN" },
                    { "aea97cb7-5138-4ea8-8a76-9caf94386b05", null, "User", "USER" }
                });
        }
    }
}
