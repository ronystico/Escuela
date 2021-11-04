using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class EstudiantesdeCursoPeriodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "94821b49-56b1-477b-a94f-5eedb77e2068");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "71ae821a-7d06-4459-8ca5-1c6a38a73512");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "964020ef-5312-42db-b539-c0869f44435a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b86d1b85-b20a-4ac6-bb21-aa8ef9a6bd15", new DateTime(2021, 11, 3, 23, 10, 6, 173, DateTimeKind.Local).AddTicks(1553), "AQAAAAEAACcQAAAAEHziXwkBr6VTea4jz6oEmNGDU7POKx34Nf2e0vMJYppsjELrif+AklqYTO+ZoruZiA==", "d9db554d-dd29-4320-a904-d50c483e0f99" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "72b2de37-7840-45a5-858d-b71b71dfd51d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "bf84df26-b37d-4d00-acbb-9a41035a8942");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "d643196a-f765-483d-a0de-791d657c4372");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f590d311-5713-47b9-a93a-1cfae2da13e0", new DateTime(2021, 10, 27, 17, 37, 44, 298, DateTimeKind.Local).AddTicks(5438), "AQAAAAEAACcQAAAAEAHc2wbv42NDr8Ic5TVDOi2VgUQjoPYGNaG0ipCNXJnEKxLKhvTj4s/EYG/XB+qwcg==", "10b49703-6492-475d-b231-5f34d5306e14" });
        }
    }
}
