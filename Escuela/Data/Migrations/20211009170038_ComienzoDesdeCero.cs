using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class ComienzoDesdeCero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_AspNetUsers_user_id",
                table: "detalle_estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_padres_id_padres",
                table: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "detalle_curso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalle_estudiante",
                table: "detalle_estudiante");

            migrationBuilder.DropIndex(
                name: "IX_detalle_estudiante_user_id",
                table: "detalle_estudiante");

            migrationBuilder.DropColumn(
                name: "id_detalle_estudiante",
                table: "detalle_estudiante");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "detalle_estudiante",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "id_padres",
                table: "detalle_estudiante",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalle_estudiante",
                table: "detalle_estudiante",
                column: "UserId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserCurso_CursoIdCurso",
                table: "ApplicationUserCurso",
                column: "CursoIdCurso");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_AspNetUsers_UserId",
                table: "detalle_estudiante",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_padres_id_padres",
                table: "detalle_estudiante",
                column: "id_padres",
                principalTable: "padres",
                principalColumn: "id_padres",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_AspNetUsers_UserId",
                table: "detalle_estudiante");

            migrationBuilder.DropForeignKey(
                name: "FK_detalle_estudiante_padres_id_padres",
                table: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "ApplicationUserCurso");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalle_estudiante",
                table: "detalle_estudiante");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "detalle_estudiante",
                newName: "user_id");

            migrationBuilder.AlterColumn<int>(
                name: "id_padres",
                table: "detalle_estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_detalle_estudiante",
                table: "detalle_estudiante",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalle_estudiante",
                table: "detalle_estudiante",
                column: "id_detalle_estudiante");

            migrationBuilder.CreateTable(
                name: "detalle_curso",
                columns: table => new
                {
                    id_detalle_curso_profesor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_curso", x => x.id_detalle_curso_profesor);
                    table.ForeignKey(
                        name: "FK_detalle_curso_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalle_curso_curso_id_curso",
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

            migrationBuilder.CreateIndex(
                name: "IX_detalle_estudiante_user_id",
                table: "detalle_estudiante",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_id_curso",
                table: "detalle_curso",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_user_id",
                table: "detalle_curso",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_AspNetUsers_user_id",
                table: "detalle_estudiante",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalle_estudiante_padres_id_padres",
                table: "detalle_estudiante",
                column: "id_padres",
                principalTable: "padres",
                principalColumn: "id_padres",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
