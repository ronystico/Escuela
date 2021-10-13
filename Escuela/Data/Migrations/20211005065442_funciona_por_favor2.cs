using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class funciona_por_favor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "d3b6b644-6ced-49ba-8898-b4393706ca82");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "8df7ccf0-4d18-456b-b56c-041a3fc036f7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "329298b8-0747-4864-a4ef-67e0c5121901");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e976124-af77-4a68-bab3-85c9937f8771", "AQAAAAEAACcQAAAAEJrusXtt6NVk9+ECSFOIf+wQK9J3M6+1jRZt42g75uAjlb5nD7ubICKHFS+vtaDt9g==", "3eb4434f-64dc-4210-a1e3-5203bf1e462d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "fc94273c-c681-497f-89cb-73cb45c665fb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "606035c2-5557-44d2-aee1-a0e9842986b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "ba80ac29-50c3-4fc6-a489-a056d4b5fc28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e31d197-b610-4da5-a628-1c6bf4a7241b", "AQAAAAEAACcQAAAAEOyPpJTm3tmshrbOB28WetDxZFjKK6Jel8dP8OzbgoD8DDZSvRPyn3ixCjaX10o0Lw==", "992841cf-b88a-4b81-ade7-decb73af0c7d" });
        }
    }
}
