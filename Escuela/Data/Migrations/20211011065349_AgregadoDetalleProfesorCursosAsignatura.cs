using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class AgregadoDetalleProfesorCursosAsignatura : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserCurso");

            migrationBuilder.CreateTable(
                name: "detalle_profesor_cursos_asignatura",
                columns: table => new
                {
                    id_detalle_profesor_cursos_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_detalle_cursos_asignatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_profesor_cursos_asignatura", x => x.id_detalle_profesor_cursos_asignatura);
                    table.ForeignKey(
                        name: "FK_detalle_profesor_cursos_asignatura_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalle_profesor_cursos_asignatura_detalle_cursos_asignatura_id_detalle_cursos_asignatura",
                        column: x => x.id_detalle_cursos_asignatura,
                        principalTable: "detalle_cursos_asignatura",
                        principalColumn: "id_detalle_cursos_asignatura",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursos_asignatura_id_detalle_cursos_asignatura",
                table: "detalle_profesor_cursos_asignatura",
                column: "id_detalle_cursos_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursos_asignatura_UserId",
                table: "detalle_profesor_cursos_asignatura",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_profesor_cursos_asignatura");

            migrationBuilder.CreateTable(
                name: "ApplicationUserCurso",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CursoIdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserCurso", x => new { x.ApplicationUserId, x.CursoIdCurso });
                    table.ForeignKey(
                        name: "FK_ApplicationUserCurso_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserCurso_curso_CursoIdCurso",
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
                name: "IX_ApplicationUserCurso_CursoIdCurso",
                table: "ApplicationUserCurso",
                column: "CursoIdCurso");
        }
    }
}
