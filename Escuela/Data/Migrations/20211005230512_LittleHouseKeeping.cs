using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class LittleHouseKeeping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "estado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2e5d25fc-2837-4de2-99de-3d5dd530f6d3", "Inscrito", "AQAAAAEAACcQAAAAEPvC76TWxvplPLZAJANGP2xU0ZOgC223bCot2vTWV1P2XETIiaUbyPF8nP/oDM9Vpw==", "9a0e58ec-fbf1-439c-a8d6-63eb02df9143" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "1fdd61e0-96aa-454e-a55a-617b43c4d1b5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "af2fe148-1993-4a11-b6da-18c31c49b571");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "806ca048-c59e-4122-9bdf-cd3ae3510286");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "estado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d6b84d3-9409-4f61-a3da-c602a4ce3696", "Activo", "AQAAAAEAACcQAAAAEEwXva8iSs4fPeLqHy1XKNBiH7+tl9SZj1D725ruG6kgzNofQo+bCtny3Zrgbz0cRA==", "96d0af98-0313-455a-9e50-f45b461d084c" });
        }
    }
}
