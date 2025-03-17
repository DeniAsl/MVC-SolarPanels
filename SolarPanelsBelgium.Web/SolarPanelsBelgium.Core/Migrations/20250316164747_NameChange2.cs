using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarPanelsBelgium.Core.Migrations
{
    /// <inheritdoc />
    public partial class NameChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEKde8cQoflULOOLU9jhmNJxsVm15IC+c7RTbf5EizpMVcD/wkbR3e9N87OsMIeEaQw==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEImWtOi3Vv1B4qUfHu9RgkeT4GQyfIOwuyOtWlgWmTPNrkWgPjijOPvBP3xe/ihjUQ==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
