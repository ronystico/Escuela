using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class ProbandoMuchosaMuchos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AsignaturaCurso");

            migrationBuilder.CreateTable(
                name: "detalle_cursos_asignatura",
                columns: table => new
                {
                    id_detalle_cursos_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    id_asignatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_cursos_asignatura", x => x.id_detalle_cursos_asignatura);
                    table.ForeignKey(
                        name: "FK_detalle_cursos_asignatura_asignatura_id_asignatura",
                        column: x => x.id_asignatura,
                        principalTable: "asignatura",
                        principalColumn: "id_asignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_cursos_asignatura_curso_id_curso",
                        column: x => x.id_curso,
                        principalTable: "curso",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "10b74c8c-3698-48de-9f3a-3525a70edc52");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "9feb6cd2-39cd-4b26-812e-de4b71d93aa6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "c2be4613-8fd9-4fb9-8e9c-2e404137ceba");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ba98b84-8ad4-498f-bc24-1a36cbe325fd", "AQAAAAEAACcQAAAAEC9EGjZG/s451RIBdvbKwZTS4xIY41AYjYu6O/k68bHgWOVeJYvtIHaye0NGeIVLwQ==", "296d0f19-c581-4570-a941-e4ca55b2d63e" });

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursos_asignatura_id_asignatura",
                table: "detalle_cursos_asignatura",
                column: "id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursos_asignatura_id_curso",
                table: "detalle_cursos_asignatura",
                column: "id_curso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_cursos_asignatura");

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
    }
}
