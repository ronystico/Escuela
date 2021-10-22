using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class FechaAgregadoySemilla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deshabilitado",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_agregado",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "4499e376-6653-4b1a-b58b-3bf567f6a523");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "8046647d-88c5-45c3-b49b-271aa146780e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "1023bcbf-e3c8-476b-9716-adff7733dda4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "nombres", "NormalizedUserName", "PasswordHash", "primer_apellido", "SecurityStamp", "segundo_apellido", "UserName" },
                values: new object[] { "be14649c-d060-432c-ae8f-7d668dfe3a12", new DateTime(2021, 10, 21, 18, 1, 53, 191, DateTimeKind.Local).AddTicks(8845), "Administrador", "ADMINISTRADOR", "AQAAAAEAACcQAAAAEKruQG2BQfg1NSr3dDNW0A9Q1TpYwiu6C7m9kfid4TaDo7c9JX0xqdyWDS3e+xgMcw==", "Administrando", "63dc7bff-21d6-45a5-bbcc-4077e60e999b", "Administración", "administrador" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_agregado",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "deshabilitado",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "6e903144-6c01-48b8-902b-19d1915a099c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "4524a6d3-78b7-4eed-b0e0-1e2ab2784d27");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "ceef0688-b21d-4069-9e4b-3c0329af4680");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "nombres", "NormalizedUserName", "PasswordHash", "primer_apellido", "SecurityStamp", "segundo_apellido", "UserName" },
                values: new object[] { "0e0085b7-3a55-4f24-85ab-676648b85dd2", "Klk Compay", "KLKCOMPAY@DOMINICAN.COM", "AQAAAAEAACcQAAAAEMjunaaTISDEF7A4SI+g7zQdu8iZRW5xzglF44QSg1IFgbjJzfdd4kr9L5Wn9O8Vkg==", "Dominicano", "d5ada811-b0b4-4b2e-8625-df3b75852d9f", "Soy", "klkcompay@dominican.com" });
        }
    }
}
