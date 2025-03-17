using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarPanelsBelgium.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProps2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAENjGeYQJCHp4BNE/hjIV6SDWosGmzdwxCyCV9l3CXB7fLf1k2LOvUUHs89g36mr3cA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEN4N0k2r2qcv1uKMZAaLBjAEeJSiV9D8Atby6QeQQS6joTbRugqKKtxiGP8Rj6Hbjg==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEDhUJBQPNe57PgOIYiBqSisZ6El/bm/bP72fS+ldwCAXAJpGEkMKETDFEK+S1T1oSA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEI+7VZJShTrz5kqvaxH3nPFfpCH5UF0JDUxGR7y0K/VgLD3n7L6f5HcbPsjhVDdf0Q==");
        }
    }
}
