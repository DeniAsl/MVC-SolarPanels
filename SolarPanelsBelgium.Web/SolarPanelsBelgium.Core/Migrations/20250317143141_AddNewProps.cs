using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarPanelsBelgium.Core.Migrations
{
    /// <inheritdoc />
    public partial class AddNewProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "SolarPanels",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SolarPanels",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "SolarPanels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SolarPanels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000001",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEBW0nayrAvLS+Xv9EcNJxQSHYDKlUolO3o37YydcPXKyVEgQTxC5wiDWoKvDuiaIBQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-0000-0000-0000-000000000002",
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEECdjko05CG3vyMEEYL4EplpoqszZ0QUnDnEVLOS5h1WchcC3Jw/s2WksnB7B1j6kg==");
        }
    }
}
