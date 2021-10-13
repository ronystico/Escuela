using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class EliminadosCamposSobrantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fecha_de_nacimiento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "fee513a1-e80e-4415-8f50-eb3e0c4e8e3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "3d83b049-8463-4cc6-9fcf-6226baddd0b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "7753820b-db0d-4752-9d8d-2ca72bc13cc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4abfcb2-a609-4bf1-92ce-3e6099bf35e0", "AQAAAAEAACcQAAAAEDgrzSivNzPaRpE3PfoUsPxz9NWdJXbT7aN7ZnidlpUNHgaUnynP7z7KDf5+8unniw==", "49349b0c-1964-4f20-944d-2990a30c2f54" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_de_nacimiento",
                table: "AspNetUsers",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "249124bf-4595-4ac9-956e-596f3eabc3cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "6579f01d-ec2d-4b25-8505-279cf5cce8cf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "3971caa5-f604-4eda-aaff-205256ee0ba3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "direccion", "fecha_de_nacimiento", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5d25fc-2837-4de2-99de-3d5dd530f6d3", "Algun lado", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAEAACcQAAAAEPvC76TWxvplPLZAJANGP2xU0ZOgC223bCot2vTWV1P2XETIiaUbyPF8nP/oDM9Vpw==", "9a0e58ec-fbf1-439c-a8d6-63eb02df9143" });
        }
    }
}
