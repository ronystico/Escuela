using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class CursoPeriodoAsignaturayCalificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "ff58a46a-2e69-4296-a94e-ee7ac3740c45");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "060b0d9d-6325-46c7-b016-8162f1413c1c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "8ee3e541-5d72-4502-aac5-c3614d3ba392");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ff93d35-2498-4871-ba0e-9e987ac82ce3", new DateTime(2021, 11, 3, 23, 40, 42, 347, DateTimeKind.Local).AddTicks(9579), "AQAAAAEAACcQAAAAEFolIJa7SPma69Wdgjj7XJ45TvHB5/WIpXc4W8mWXlJO+mGulhUzQ6ecSIaT0osYtw==", "60221b44-c445-4041-bb5e-09d0c79ed2fa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
