using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Migrations
{
    public partial class MejoradaNormalizacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_o_rne",
                table: "detalle_estudiante",
                newName: "rne");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_edicion",
                table: "noticia",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "id_estudiante",
                table: "detalle_estudiante",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "c392f1e5-fd10-4a27-bee1-7e35a8404593");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "c6cda4b0-0e6d-4712-9ca8-2aba9cca53bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "a81db4b9-3b38-413a-b293-d03d318d01c8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62a52ebe-563f-43bd-9d28-f71d7bdd1d8c", new DateTime(2021, 12, 2, 0, 20, 30, 735, DateTimeKind.Local).AddTicks(1070), "AQAAAAEAACcQAAAAEP7TTwx1HO10lIS0KEGFuc1zK2DoENJvxwCac9nmkaSJb3FdJyWUBuC7WuSRCvUbTw==", "2fa18194-325a-40f6-b027-d48b65ba3fbd" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fecha_edicion",
                table: "noticia");

            migrationBuilder.DropColumn(
                name: "id_estudiante",
                table: "detalle_estudiante");

            migrationBuilder.RenameColumn(
                name: "rne",
                table: "detalle_estudiante",
                newName: "id_o_rne");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "04f19dcd-45ae-4d43-bf31-62db29b69ad8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "f7a1e7da-a2c0-4a38-b65e-4ec6513f82a2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "93b8ce24-0161-4ce1-8194-e01557b38109");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20f132ed-68a9-42cd-9a9f-2a1722659765", new DateTime(2021, 11, 27, 3, 14, 47, 252, DateTimeKind.Local).AddTicks(9759), "AQAAAAEAACcQAAAAEF3N7YoOQtNUlrZHIKnPq/r+5UbtB53/j2zR3Cf1K21bmY2c/qKZ3ZULVqznyixL8A==", "f2aa3eb2-841c-48af-a23f-043cc9df6178" });
        }
    }
}
