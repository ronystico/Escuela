using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class AgregadoEstadoyDeshabilitado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "deshabilitado",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "e4300242-5262-463d-8ea6-2901df8317f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "40e14a8e-dc2c-4568-8d43-d7a267c37bb1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "3b922319-5963-4ab6-abbb-d907380624d8");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "estado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02135be0-89a1-4251-8c07-483d868e869d", "Activo", "AQAAAAEAACcQAAAAEEI4SDz/g++AJNgxW+MGxlt0roTuKHgPz9NLRG746nBF5lbxqXPpbI7kmudZgNWX2w==", "a7d5cbca-c4cd-4a7f-a80d-bdd5dd47aa55" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "deshabilitado",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "6a0c6057-8888-4946-80ad-2e5ad30c7ed0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "81ca5a44-4bff-4e70-b960-31e69b01f686");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "3512840c-4bba-4df9-828c-14a8e6573557");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "180a696d-0a13-458c-a285-a1703d6e59d2", "AQAAAAEAACcQAAAAEI/sDFXgCx+0ST9T74T0ENSPmkrYQgFAm96Wa6FRIegkm0IndGOvBHjsu7p3ViJ4bw==", "96379148-fa8d-4770-a8b8-c50914c24668" });
        }
    }
}
