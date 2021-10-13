using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class funciona_por_favor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "detalle_curso",
                columns: table => new
                {
                    id_detalle_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    id_curso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_curso", x => x.id_detalle_curso);
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

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_id_curso",
                table: "detalle_curso",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_curso_user_id",
                table: "detalle_curso",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_curso");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "AspNetUsers");
        }
    }
}
