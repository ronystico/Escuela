using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class AgregadoAsignatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.id_asignatura);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "68bed2d9-9976-4afa-a922-283c5c61d8d3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "0c0b5571-5832-4f0b-ab1e-1fb6e7e97703");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "e561abdf-c357-4bb4-adf9-3443ad021c02");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3fd5418-04a2-4c17-bcdc-207a4b002c2b", "AQAAAAEAACcQAAAAEELBFudwUZw91WWUZjHl6oUz3legHDQum9oaX/4/ZkPIWqeroTh/MmiTnQxfZ61UOQ==", "c68ed27f-cad9-415f-91b8-55a5eae9e7ac" });
        }
    }
}
