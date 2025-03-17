using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarPanelsBelgium.Core.Migrations
{
    /// <inheritdoc />
    public partial class NameChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEGou6fWp9RHTc5qAyu06Gp6wWvI4kC0BC2t9ac5Ue+qR0e6qHS/nYftXRjYlVqlhfg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEB64sG5fXJ4jZ1ONSZhDjXEk9SxAYLvOEhwpOUcenpgfGQXERcuUdvohKc0ToW8xMA==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEPKfMCrSu27QSz2F1SsX8KnvRGDl/Y9C6lj+Gb/7D3OZ5ch6uprFQeXLQplMDV/2Lg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEM9XSSoBFqOL6ZriGGZIDUb3tWnnOQQRrJAi0ihqIM3Kq8N4KsB05En5FyGWZcgKag==");
        }
    }
}
