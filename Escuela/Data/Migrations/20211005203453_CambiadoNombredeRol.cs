using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class CambiadoNombredeRol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "ea762846-7a40-4f43-b2c1-3da45001c6d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0281612d-cc70-40e2-854b-bdb80e35606f", "Administracion", "ADMINISTRACION" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "5f3db466-7dd6-4728-9920-5b55076107df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49c3fcc0-1f0c-43ec-8df1-aae58d0ef56f", "AQAAAAEAACcQAAAAEL7sossi/uS+qgN0X+IA3y7d6moV7iPhg+fIYNeOInBWXhVuawThPwCA7eCfoBIjLQ==", "f628c20e-aefd-4bc5-83a9-24255e0ab3f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "d3b6b644-6ced-49ba-8898-b4393706ca82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8df7ccf0-4d18-456b-b56c-041a3fc036f7", "Direccion", "DIRECCION" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "329298b8-0747-4864-a4ef-67e0c5121901");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e976124-af77-4a68-bab3-85c9937f8771", "AQAAAAEAACcQAAAAEJrusXtt6NVk9+ECSFOIf+wQK9J3M6+1jRZt42g75uAjlb5nD7ubICKHFS+vtaDt9g==", "3eb4434f-64dc-4210-a1e3-5203bf1e462d" });
        }
    }
}
