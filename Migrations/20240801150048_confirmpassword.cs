using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class confirmpassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedDate", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8223cac9-8cad-4eaf-9dce-a52f24ad5d6a", null, new DateTime(2024, 8, 1, 11, 0, 46, 359, DateTimeKind.Local).AddTicks(2840), "Roles", "Admin", "ADMIN" },
                    { "d978abe0-5183-41a8-8770-8d6d2fab8052", null, new DateTime(2024, 8, 1, 11, 0, 46, 359, DateTimeKind.Local).AddTicks(2850), "Roles", "ReadyOnly", "READONLY" },
                    { "e78f4f51-1c8f-4687-982e-7f823c8de8e7", null, new DateTime(2024, 8, 1, 11, 0, 46, 359, DateTimeKind.Local).AddTicks(2810), "Roles", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8223cac9-8cad-4eaf-9dce-a52f24ad5d6a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d978abe0-5183-41a8-8770-8d6d2fab8052");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e78f4f51-1c8f-4687-982e-7f823c8de8e7");

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
    }
}
