using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class AgregadoOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4671823f-f30c-445c-8433-c9edb7d7caa8", "81ca5a44-4bff-4e70-b960-31e69b01f686", "Direccion", "DIRECCION" },
                    { "1ae745c4-32de-4d4b-b941-39315e76c62b", "6a0c6057-8888-4946-80ad-2e5ad30c7ed0", "Profesor", "PROFESOR" },
                    { "b5042ce0-f40d-483e-8514-e014b145b4d9", "3512840c-4bba-4df9-828c-14a8e6573557", "Estudiante", "ESTUDIANTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "direccion", "Email", "EmailConfirmed", "fecha_de_nacimiento", "LockoutEnabled", "LockoutEnd", "nombres", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "primer_apellido", "SecurityStamp", "segundo_apellido", "TwoFactorEnabled", "UserName" },
                values: new object[] { "29ce004f-6192-496b-a359-56bbbfd90ca1", 0, "180a696d-0a13-458c-a285-a1703d6e59d2", "Algun lado", null, false, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Klk Compay", null, "KLKCOMPAY@DOMINICAN.COM", "AQAAAAEAACcQAAAAEI/sDFXgCx+0ST9T74T0ENSPmkrYQgFAm96Wa6FRIegkm0IndGOvBHjsu7p3ViJ4bw==", null, false, "Dominicano", "96379148-fa8d-4770-a8b8-c50914c24668", "Soy", false, "klkcompay@dominican.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4671823f-f30c-445c-8433-c9edb7d7caa8", "29ce004f-6192-496b-a359-56bbbfd90ca1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4671823f-f30c-445c-8433-c9edb7d7caa8", "29ce004f-6192-496b-a359-56bbbfd90ca1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1");

            migrationBuilder.AlterColumn<string>(
                name: "direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
