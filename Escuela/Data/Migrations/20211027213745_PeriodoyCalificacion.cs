using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class PeriodoyCalificacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_curso_id_curso",
                table: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "detalle_profesor_cursos_asignatura");

            migrationBuilder.DropTable(
                name: "detalle_cursos_asignatura");

            migrationBuilder.RenameColumn(
                name: "id_curso",
                table: "detalle_estudiante",
                newName: "id_detalle_curso_periodo");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_estudiante_id_curso",
                table: "detalle_estudiante",
                newName: "IX_detalle_estudiante_id_detalle_curso_periodo");

            migrationBuilder.AlterColumn<string>(
                name: "id_o_rne",
                table: "detalle_estudiante",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "asignatura",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "periodo",
                columns: table => new
                {
                    id_periodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    subperiodo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_periodo", x => x.id_periodo);
                });

            migrationBuilder.CreateTable(
                name: "detalle_curso_periodo",
                columns: table => new
                {
                    id_detalle_curso_periodo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    id_periodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_curso_periodo", x => x.id_detalle_curso_periodo);
                    table.ForeignKey(
                        name: "FK_detalle_curso_periodo_curso_id_curso",
                        column: x => x.id_curso,
                        principalTable: "curso",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_curso_periodo_periodo_id_periodo",
                        column: x => x.id_periodo,
                        principalTable: "periodo",
                        principalColumn: "id_periodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_cursoperiodo_asignatura",
                columns: table => new
                {
                    id_detalle_cursoperiodo_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_detalle_curso_periodo = table.Column<int>(type: "int", nullable: false),
                    id_asignatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_cursoperiodo_asignatura", x => x.id_detalle_cursoperiodo_asignatura);
                    table.ForeignKey(
                        name: "FK_detalle_cursoperiodo_asignatura_asignatura_id_asignatura",
                        column: x => x.id_asignatura,
                        principalTable: "asignatura",
                        principalColumn: "id_asignatura",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_cursoperiodo_asignatura_detalle_curso_periodo_id_detalle_curso_periodo",
                        column: x => x.id_detalle_curso_periodo,
                        principalTable: "detalle_curso_periodo",
                        principalColumn: "id_detalle_curso_periodo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "calificacion",
                columns: table => new
                {
                    id_calificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estudiante = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_profesor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_detallecursoperiodo_asignatura = table.Column<int>(type: "int", nullable: false),
                    fecha_asignada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_editada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    calificacion_total = table.Column<int>(type: "int", nullable: false),
                    observacion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificacion", x => x.id_calificacion);
                    table.ForeignKey(
                        name: "FK_calificacion_AspNetUsers_id_estudiante",
                        column: x => x.id_estudiante,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calificacion_AspNetUsers_id_profesor",
                        column: x => x.id_profesor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calificacion_detalle_cursoperiodo_asignatura_id_detallecursoperiodo_asignatura",
                        column: x => x.id_detallecursoperiodo_asignatura,
                        principalTable: "detalle_cursoperiodo_asignatura",
                        principalColumn: "id_detalle_cursoperiodo_asignatura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detalle_profesor_cursoperiodo_asignatura",
                columns: table => new
                {
                    id_detalle_profesor_cursoperiodo_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_detalle_cursoperiodo_asignatura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_profesor_cursoperiodo_asignatura", x => x.id_detalle_profesor_cursoperiodo_asignatura);
                    table.ForeignKey(
                        name: "FK_detalle_profesor_cursoperiodo_asignatura_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalle_profesor_cursoperiodo_asignatura_detalle_cursoperiodo_asignatura_id_detalle_cursoperiodo_asignatura",
                        column: x => x.id_detalle_cursoperiodo_asignatura,
                        principalTable: "detalle_cursoperiodo_asignatura",
                        principalColumn: "id_detalle_cursoperiodo_asignatura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "72b2de37-7840-45a5-858d-b71b71dfd51d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "bf84df26-b37d-4d00-acbb-9a41035a8942");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "d643196a-f765-483d-a0de-791d657c4372");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f590d311-5713-47b9-a93a-1cfae2da13e0", new DateTime(2021, 10, 27, 17, 37, 44, 298, DateTimeKind.Local).AddTicks(5438), "AQAAAAEAACcQAAAAEAHc2wbv42NDr8Ic5TVDOi2VgUQjoPYGNaG0ipCNXJnEKxLKhvTj4s/EYG/XB+qwcg==", "10b49703-6492-475d-b231-5f34d5306e14" });

            migrationBuilder.CreateIndex(
                name: "IX_calificacion_id_detallecursoperiodo_asignatura",
                table: "calificacion",
                column: "id_detallecursoperiodo_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_calificacion_id_estudiante",
                table: "calificacion",
                column: "id_estudiante");

            migrationBuilder.CreateIndex(
                name: "IX_calificacion_id_profesor",
                table: "calificacion",
                column: "id_profesor");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_periodo_id_curso",
                table: "detalle_curso_periodo",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_periodo_id_periodo",
                table: "detalle_curso_periodo",
                column: "id_periodo");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursoperiodo_asignatura_id_asignatura",
                table: "detalle_cursoperiodo_asignatura",
                column: "id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursoperiodo_asignatura_id_detalle_curso_periodo",
                table: "detalle_cursoperiodo_asignatura",
                column: "id_detalle_curso_periodo");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursoperiodo_asignatura_id_detalle_cursoperiodo_asignatura",
                table: "detalle_profesor_cursoperiodo_asignatura",
                column: "id_detalle_cursoperiodo_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursoperiodo_asignatura_UserId",
                table: "detalle_profesor_cursoperiodo_asignatura",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_detalle_curso_periodo_id_detalle_curso_periodo",
                table: "detalle_estudiante",
                column: "id_detalle_curso_periodo",
                principalTable: "detalle_curso_periodo",
                principalColumn: "id_detalle_curso_periodo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_detalle_curso_periodo_id_detalle_curso_periodo",
                table: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "calificacion");

            migrationBuilder.DropTable(
                name: "detalle_profesor_cursoperiodo_asignatura");

            migrationBuilder.DropTable(
                name: "detalle_cursoperiodo_asignatura");

            migrationBuilder.DropTable(
                name: "detalle_curso_periodo");

            migrationBuilder.DropTable(
                name: "periodo");

            migrationBuilder.RenameColumn(
                name: "id_detalle_curso_periodo",
                table: "detalle_estudiante",
                newName: "id_curso");

            migrationBuilder.RenameIndex(
                name: "IX_detalle_estudiante_id_detalle_curso_periodo",
                table: "detalle_estudiante",
                newName: "IX_detalle_estudiante_id_curso");

            migrationBuilder.AlterColumn<string>(
                name: "id_o_rne",
                table: "detalle_estudiante",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombre",
                table: "asignatura",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "detalle_cursos_asignatura",
                columns: table => new
                {
                    id_detalle_cursos_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_asignatura = table.Column<int>(type: "int", nullable: false),
                    id_curso = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "detalle_profesor_cursos_asignatura",
                columns: table => new
                {
                    id_detalle_profesor_cursos_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_detalle_cursos_asignatura = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
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
                value: "4499e376-6653-4b1a-b58b-3bf567f6a523");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "8046647d-88c5-45c3-b49b-271aa146780e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "1023bcbf-e3c8-476b-9716-adff7733dda4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be14649c-d060-432c-ae8f-7d668dfe3a12", new DateTime(2021, 10, 21, 18, 1, 53, 191, DateTimeKind.Local).AddTicks(8845), "AQAAAAEAACcQAAAAEKruQG2BQfg1NSr3dDNW0A9Q1TpYwiu6C7m9kfid4TaDo7c9JX0xqdyWDS3e+xgMcw==", "63dc7bff-21d6-45a5-bbcc-4077e60e999b" });

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursos_asignatura_id_asignatura",
                table: "detalle_cursos_asignatura",
                column: "id_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_cursos_asignatura_id_curso",
                table: "detalle_cursos_asignatura",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursos_asignatura_id_detalle_cursos_asignatura",
                table: "detalle_profesor_cursos_asignatura",
                column: "id_detalle_cursos_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursos_asignatura_UserId",
                table: "detalle_profesor_cursos_asignatura",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_curso_id_curso",
                table: "detalle_estudiante",
                column: "id_curso",
                principalTable: "curso",
                principalColumn: "id_curso",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
