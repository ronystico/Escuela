using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class AgregadasTablasFaltantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_detalle_curso",
                table: "detalle_curso",
                newName: "id_detalle_curso_profesor");

            migrationBuilder.CreateTable(
                name: "padres",
                columns: table => new
                {
                    id_padres = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primer_apellido_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    segundo_apellido_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombres_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telefono_madre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    primer_apellido_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    segundo_apellido_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombres_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    telefono_padre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_padres", x => x.id_padres);
                });

            migrationBuilder.CreateTable(
                name: "detalle_estudiante",
                columns: table => new
                {
                    id_detalle_estudiante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_curso = table.Column<int>(type: "int", nullable: false),
                    numero_de_orden = table.Column<int>(type: "int", nullable: false),
                    id_padres = table.Column<int>(type: "int", nullable: false),
                    id_o_rne = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_estudiante", x => x.id_detalle_estudiante);
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_curso_id_curso",
                        column: x => x.id_curso,
                        principalTable: "curso",
                        principalColumn: "id_curso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_padres_id_padres",
                        column: x => x.id_padres,
                        principalTable: "padres",
                        principalColumn: "id_padres",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_detalle_estudiante_id_curso",
                table: "detalle_estudiante",
                column: "id_curso");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_estudiante_id_padres",
                table: "detalle_estudiante",
                column: "id_padres");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_estudiante_user_id",
                table: "detalle_estudiante",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "padres");

            migrationBuilder.RenameColumn(
                name: "id_detalle_curso_profesor",
                table: "detalle_curso",
                newName: "id_detalle_curso");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "fee513a1-e80e-4415-8f50-eb3e0c4e8e3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "3d83b049-8463-4cc6-9fcf-6226baddd0b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "7753820b-db0d-4752-9d8d-2ca72bc13cc3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4abfcb2-a609-4bf1-92ce-3e6099bf35e0", "AQAAAAEAACcQAAAAEDgrzSivNzPaRpE3PfoUsPxz9NWdJXbT7aN7ZnidlpUNHgaUnynP7z7KDf5+8unniw==", "49349b0c-1964-4f20-944d-2990a30c2f54" });
        }
    }
}
