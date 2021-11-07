using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class DataAnnotationsFechas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "10d1e6ff-dcd5-4fbe-9fab-d2543b09f4a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "3bdf9e17-143b-456c-ab6a-4ae2a48fbb8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "9749c088-e2c5-4e2d-b11d-710944427838");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6a2eb33-3cac-448d-81d2-6af4ef468660", new DateTime(2021, 11, 4, 12, 36, 49, 664, DateTimeKind.Local).AddTicks(9682), "AQAAAAEAACcQAAAAEJTqXs83M5nto44xqRZ4vbDTwEbklhicYZVYUSxigeqv8McOxCZ6sJz3tz6qvwEYig==", "8eb6091f-ccca-47e9-8e23-4b52949238b8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
