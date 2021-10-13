using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class RelacionCursoAsignatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AsignaturaCurso",
                columns: table => new
                {
                    AsignaturaIdAsignatura = table.Column<int>(type: "int", nullable: false),
                    CursoIdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AsignaturaCurso", x => new { x.AsignaturaIdAsignatura, x.CursoIdCurso });
                    table.ForeignKey(
                        name: "FK_AsignaturaCurso_asignatura_AsignaturaIdAsignatura",
                        column: x => x.AsignaturaIdAsignatura,
                        principalTable: "asignatura",
                        principalColumn: "id_asignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AsignaturaCurso_curso_CursoIdCurso",
                        column: x => x.CursoIdCurso,
                        principalTable: "curso",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "a5089c66-ab28-427a-bac0-cdc7e7841f31");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "0a561e4b-da8e-42b1-869c-209c7aca2710");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "46ee1f06-152c-438f-bcfc-894acb959ea1");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c552cac-9d9b-4da7-9397-b68a35564f6f", "AQAAAAEAACcQAAAAEN0wvYh0+dfAVXwwLIorYyY4goPsgqDJxMPqzRvid0QmpyB5PBLO/lAA5DTsTHuOVg==", "aa4a1565-6620-4eb4-b6d1-b6f589f7c3ba" });

            migrationBuilder.CreateIndex(
                name: "IX_AsignaturaCurso_CursoIdCurso",
                table: "AsignaturaCurso",
                column: "CursoIdCurso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaCurso");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "9c269125-24af-472e-b88f-81e8aba6a7d1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "a8b2dc06-371f-4093-8368-5cda502dc24b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "bd6697e9-2a32-4f9f-858f-267c0946c815");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71f67004-332f-4bf2-9ed0-50f6ca469755", "AQAAAAEAACcQAAAAEO3roOHiKMMRG9fYUmmOf8ddcWE6wQJATD/xPSTPALLG92q3b6UqsUSL54qbxSIaSQ==", "74ed1807-39cf-4b31-ac36-86d3b0f4c341" });
        }
    }
}
