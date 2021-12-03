using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Migrations
{
    public partial class TablaPreguntaFrecuente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pregunta_frecuente",
                columns: table => new
                {
                    id_pregunta_frecuente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pregunta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    respuesta = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregunta_frecuente", x => x.id_pregunta_frecuente);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "7b282ba8-fad3-4160-b229-db357d8f2f92");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "c9ad2d33-2a82-4273-9dc3-5f7e076a6987");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "052970aa-03e6-48a4-b528-b4096777d4a3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a4119a38-ba7b-4ca2-a1b3-8312571f1e13", new DateTime(2021, 12, 2, 0, 48, 32, 725, DateTimeKind.Local).AddTicks(1682), "AQAAAAEAACcQAAAAEAmuub9YZlMbxOtNqlYEqyDwiCI1SB9bn8WfZXaFMx4GCo+wYNIjgBh8heir013ZIQ==", "89469764-b6be-4301-aee4-03f78dcf90df" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pregunta_frecuente");

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
    }
}
