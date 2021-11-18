using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Data.Migrations
{
    public partial class Noticias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "noticia",
                columns: table => new
                {
                    id_noticia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_categoria_noticia = table.Column<int>(type: "int", nullable: false),
                    id_autor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cuerpo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha_publicacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_noticia", x => x.id_noticia);
                    table.ForeignKey(
                        name: "FK_noticia_AspNetUsers_id_autor",
                        column: x => x.id_autor,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_noticia_categoria_noticia_id_categoria_noticia",
                        column: x => x.id_categoria_noticia,
                        principalTable: "categoria_noticia",
                        principalColumn: "id_categoria_noticia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "0836f672-378f-4d3f-91d6-804c12498636");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "b1599eab-b967-4320-a68d-86b1fcd5768f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "99eebc02-72b5-4f1a-9f2c-87b0c283417a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5be7e56e-1353-4a2a-a4bf-b484b7673606", new DateTime(2021, 11, 17, 20, 20, 52, 865, DateTimeKind.Local).AddTicks(2462), "AQAAAAEAACcQAAAAEFU5xr3FVa8N4pDzoA1qnjLNyXb8nAms2envwvRaWokL3yS0C/BgjDIBr+bcRF7fzA==", "9790297f-31ef-48cf-9e8c-84e72aacdfa8" });

            migrationBuilder.InsertData(
                table: "categoria_noticia",
                columns: new[] { "id_categoria_noticia", "Nombre" },
                values: new object[] { 1, "General" });

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
                name: "noticia");

            migrationBuilder.DropTable(
                name: "categoria_noticia");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "146fbbfd-f5f2-4f35-9dac-b0d3df1a4395");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "2250454c-cb69-4c92-8992-766c3f91ec2d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "284a5b6f-3c1e-484a-ad5c-bc9a8bcd9aef");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7a076a8-e724-44bd-98b8-6ddb17821ec8", new DateTime(2021, 11, 14, 0, 35, 47, 748, DateTimeKind.Local).AddTicks(1559), "AQAAAAEAACcQAAAAEATWWYsFLLCOenbC4IISCXLD/Mb5oULzmGuRX0viz/GIl/HAubze6Q/njqd3wUtmxw==", "bf6bdfa5-d69b-43f5-9390-c7e35526f037" });
        }
    }
}
