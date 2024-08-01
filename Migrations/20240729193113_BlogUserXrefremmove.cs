using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class BlogUserXrefremmove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2856648d-bb6d-4dbe-ae5a-6c1fe34ec7b2", null, new DateTime(2024, 7, 29, 19, 31, 12, 596, DateTimeKind.Utc).AddTicks(5830), "Roles", "ReadyOnly", "READONLY" },
                    { "5ee8567e-e427-475e-a720-16d488e96f83", null, new DateTime(2024, 7, 29, 19, 31, 12, 596, DateTimeKind.Utc).AddTicks(5820), "Roles", "Admin", "ADMIN" },
                    { "86037bf0-9813-4855-829b-ca56b4dd9332", null, new DateTime(2024, 7, 29, 19, 31, 12, 596, DateTimeKind.Utc).AddTicks(5800), "Roles", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2856648d-bb6d-4dbe-ae5a-6c1fe34ec7b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ee8567e-e427-475e-a720-16d488e96f83");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86037bf0-9813-4855-829b-ca56b4dd9332");

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
    }
}
