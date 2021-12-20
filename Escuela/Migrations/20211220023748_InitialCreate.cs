using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "asignatura",
                columns: table => new
                {
                    id_asignatura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_asignatura", x => x.id_asignatura);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    primer_apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    segundo_apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    estado = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fecha_agregado = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "carousel",
                columns: table => new
                {
                    id_carousel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_imagen = table.Column<int>(type: "int", nullable: false),
                    imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carousel", x => x.id_carousel);
                });

            migrationBuilder.CreateTable(
                name: "categoria_noticia",
                columns: table => new
                {
                    id_categoria_noticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_noticia", x => x.id_categoria_noticia);
                });

            migrationBuilder.CreateTable(
                name: "curso",
                columns: table => new
                {
                    id_curso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    seccion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_curso", x => x.id_curso);
                });

            migrationBuilder.CreateTable(
                name: "padres",
                columns: table => new
                {
                    id_padres = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    primer_apellido_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    segundo_apellido_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombres_madre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono_madre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    primer_apellido_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    segundo_apellido_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    nombres_padre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    telefono_padre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_padres", x => x.id_padres);
                });

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
                name: "pregunta_frecuente",
                columns: table => new
                {
                    id_pregunta_frecuente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pregunta = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    respuesta = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregunta_frecuente", x => x.id_pregunta_frecuente);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "noticia",
                columns: table => new
                {
                    id_noticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria_noticia = table.Column<int>(type: "int", nullable: false),
                    id_autor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_edicion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noticia", x => x.id_noticia);
                    table.ForeignKey(
                        name: "FK_noticia_AspNetUsers_id_autor",
                        column: x => x.id_autor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_noticia_categoria_noticia_id_categoria_noticia",
                        column: x => x.id_categoria_noticia,
                        principalTable: "categoria_noticia",
                        principalColumn: "id_categoria_noticia");
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
                        principalColumn: "id_curso");
                    table.ForeignKey(
                        name: "FK_detalle_curso_periodo_periodo_id_periodo",
                        column: x => x.id_periodo,
                        principalTable: "periodo",
                        principalColumn: "id_periodo");
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
                        principalColumn: "id_asignatura");
                    table.ForeignKey(
                        name: "FK_detalle_cursoperiodo_asignatura_detalle_curso_periodo_id_detalle_curso_periodo",
                        column: x => x.id_detalle_curso_periodo,
                        principalTable: "detalle_curso_periodo",
                        principalColumn: "id_detalle_curso_periodo");
                });

            migrationBuilder.CreateTable(
                name: "detalle_estudiante",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    id_detalle_curso_periodo = table.Column<int>(type: "int", nullable: false),
                    numero_de_orden = table.Column<int>(type: "int", nullable: false),
                    id_padres = table.Column<int>(type: "int", nullable: true),
                    id_estudiante = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    rne = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalle_estudiante", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_detalle_curso_periodo_id_detalle_curso_periodo",
                        column: x => x.id_detalle_curso_periodo,
                        principalTable: "detalle_curso_periodo",
                        principalColumn: "id_detalle_curso_periodo");
                    table.ForeignKey(
                        name: "FK_detalle_estudiante_padres_id_padres",
                        column: x => x.id_padres,
                        principalTable: "padres",
                        principalColumn: "id_padres");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_calificacion_AspNetUsers_id_profesor",
                        column: x => x.id_profesor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_calificacion_detalle_cursoperiodo_asignatura_id_detallecursoperiodo_asignatura",
                        column: x => x.id_detallecursoperiodo_asignatura,
                        principalTable: "detalle_cursoperiodo_asignatura",
                        principalColumn: "id_detalle_cursoperiodo_asignatura");
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_detalle_profesor_cursoperiodo_asignatura_detalle_cursoperiodo_asignatura_id_detalle_cursoperiodo_asignatura",
                        column: x => x.id_detalle_cursoperiodo_asignatura,
                        principalTable: "detalle_cursoperiodo_asignatura",
                        principalColumn: "id_detalle_cursoperiodo_asignatura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ae745c4-32de-4d4b-b941-39315e76c62b", "789ed261-496b-4355-8f75-c8cca2bb1f62", "Profesor", "PROFESOR" },
                    { "4671823f-f30c-445c-8433-c9edb7d7caa8", "fde27ba7-7e5a-457d-b71f-5b9d02f6613a", "Administracion", "ADMINISTRACION" },
                    { "b5042ce0-f40d-483e-8514-e014b145b4d9", "a7dfb010-c8ee-428b-a1f5-a4e4ecc7d17d", "Estudiante", "ESTUDIANTE" }
                });

            migrationBuilder.InsertData(
                table: "categoria_noticia",
                columns: new[] { "id_categoria_noticia", "Nombre" },
                values: new object[] { 1, "General" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_detalle_estudiante_id_detalle_curso_periodo",
                table: "detalle_estudiante",
                column: "id_detalle_curso_periodo");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_estudiante_id_padres",
                table: "detalle_estudiante",
                column: "id_padres");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursoperiodo_asignatura_id_detalle_cursoperiodo_asignatura",
                table: "detalle_profesor_cursoperiodo_asignatura",
                column: "id_detalle_cursoperiodo_asignatura");

            migrationBuilder.CreateIndex(
                name: "IX_detalle_profesor_cursoperiodo_asignatura_UserId",
                table: "detalle_profesor_cursoperiodo_asignatura",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_noticia_id_autor",
                table: "noticia",
                column: "id_autor");

            migrationBuilder.CreateIndex(
                name: "IX_noticia_id_categoria_noticia",
                table: "noticia",
                column: "id_categoria_noticia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "calificacion");

            migrationBuilder.DropTable(
                name: "carousel");

            migrationBuilder.DropTable(
                name: "detalle_estudiante");

            migrationBuilder.DropTable(
                name: "detalle_profesor_cursoperiodo_asignatura");

            migrationBuilder.DropTable(
                name: "noticia");

            migrationBuilder.DropTable(
                name: "pregunta_frecuente");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "padres");

            migrationBuilder.DropTable(
                name: "detalle_cursoperiodo_asignatura");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "categoria_noticia");

            migrationBuilder.DropTable(
                name: "asignatura");

            migrationBuilder.DropTable(
                name: "detalle_curso_periodo");

            migrationBuilder.DropTable(
                name: "curso");

            migrationBuilder.DropTable(
                name: "periodo");
        }
    }
}
