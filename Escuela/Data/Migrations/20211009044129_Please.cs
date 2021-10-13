using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class Please : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "2796c815-5409-4b53-8ae4-487ed3f2102e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "34f5478c-deb0-4194-b927-d4deb6540ccf");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "929d1f82-bb3d-49ee-a1ac-a759063721b5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e548f35-5ce3-4e5f-9df7-650eaf0ada2e", "AQAAAAEAACcQAAAAEGk/sZ6K+KwTY8f6lxs2yi/xrSoQhiK56p0B+8o1bU5SqlMCwkz0rlJiEaePfgUEOA==", "192ad88a-d9db-4ff2-837e-5181c7e73853" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "5159927c-b96d-49bc-8e3d-8110cca635e4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "ef5e654f-254b-4fa2-b380-ab5b7186ed5c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "32ae6160-3428-42c1-ba0a-004544f473ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b47aa78-1cf3-434d-8d36-7597ec90e41d", "AQAAAAEAACcQAAAAEEJerFfpSDAKRhnouNYm2HJkowwUn+bluoGr9kBojyd63mOT1qTBMbsOvAOcXFwN/w==", "38e5ad4d-a9d7-4eca-b29c-2e29ccb2ebc6" });
        }
    }
}
