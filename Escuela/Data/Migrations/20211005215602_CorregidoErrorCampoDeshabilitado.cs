using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class CorregidoErrorCampoDeshabilitado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d6b84d3-9409-4f61-a3da-c602a4ce3696", "AQAAAAEAACcQAAAAEEwXva8iSs4fPeLqHy1XKNBiH7+tl9SZj1D725ruG6kgzNofQo+bCtny3Zrgbz0cRA==", "96d0af98-0313-455a-9e50-f45b461d084c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "ea762846-7a40-4f43-b2c1-3da45001c6d8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "0281612d-cc70-40e2-854b-bdb80e35606f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "5f3db466-7dd6-4728-9920-5b55076107df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49c3fcc0-1f0c-43ec-8df1-aae58d0ef56f", "AQAAAAEAACcQAAAAEL7sossi/uS+qgN0X+IA3y7d6moV7iPhg+fIYNeOInBWXhVuawThPwCA7eCfoBIjLQ==", "f628c20e-aefd-4bc5-83a9-24255e0ab3f0" });
        }
    }
}
