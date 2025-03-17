using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolarPanelsBelgium.Core.Migrations
{
    /// <inheritdoc />
    public partial class NameChange3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarPanelForms_AspNetUsers_ApplicationUserId",
                table: "SolarPanelForms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolarPanelForms",
                table: "SolarPanelForms");

            migrationBuilder.RenameTable(
                name: "SolarPanelForms",
                newName: "SolarPanels");

            migrationBuilder.RenameIndex(
                name: "IX_SolarPanelForms_ApplicationUserId",
                table: "SolarPanels",
                newName: "IX_SolarPanels_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolarPanels",
                table: "SolarPanels",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPanels_AspNetUsers_ApplicationUserId",
                table: "SolarPanels",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolarPanels_AspNetUsers_ApplicationUserId",
                table: "SolarPanels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SolarPanels",
                table: "SolarPanels");

            migrationBuilder.RenameTable(
                name: "SolarPanels",
                newName: "SolarPanelForms");

            migrationBuilder.RenameIndex(
                name: "IX_SolarPanels_ApplicationUserId",
                table: "SolarPanelForms",
                newName: "IX_SolarPanelForms_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SolarPanelForms",
                table: "SolarPanelForms",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_SolarPanelForms_AspNetUsers_ApplicationUserId",
                table: "SolarPanelForms",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
