using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class JaMeFaltabaUnaTabla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0e0085b7-3a55-4f24-85ab-676648b85dd2", "AQAAAAEAACcQAAAAEMjunaaTISDEF7A4SI+g7zQdu8iZRW5xzglF44QSg1IFgbjJzfdd4kr9L5Wn9O8Vkg==", "d5ada811-b0b4-4b2e-8625-df3b75852d9f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "4768de48-dbd1-401b-b1ff-69da0e3eda83");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "a332ea4e-74c9-40e2-a0f2-6c470f8ac71d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "29585e9b-ad1a-44af-8eb0-2e3671482ecf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "667d17e5-6fad-4526-a6b2-3ff049a8902e", "AQAAAAEAACcQAAAAEGfPrFwaUZZidGjDX9q4mvOfRNxxZup4pGnIJcoaSkIF35kL/3BJ1sEGRDTGmYEYyw==", "0150dec1-63ea-4ffe-a039-72e0bb509e54" });
        }
    }
}
