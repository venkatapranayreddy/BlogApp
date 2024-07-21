using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogApplication.Migrations
{
    /// <inheritdoc />
    public partial class FinalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26219123-bd50-4b9b-a4b6-f8cc92b8fb62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53d3801d-ca30-43d3-975b-0c5c3f1b846c");

            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13cdc19a-148c-489a-b268-17854279f049", null, "User", "USER" },
                    { "bd57fafb-42f8-4272-a5e4-7b112565bfae", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13cdc19a-148c-489a-b268-17854279f049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd57fafb-42f8-4272-a5e4-7b112565bfae");

            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Articles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "26219123-bd50-4b9b-a4b6-f8cc92b8fb62", null, "Admin", "ADMIN" },
                    { "53d3801d-ca30-43d3-975b-0c5c3f1b846c", null, "User", "USER" }
                });
        }
    }
}
