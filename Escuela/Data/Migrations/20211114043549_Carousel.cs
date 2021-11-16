using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escuela.Data.Migrations
{
    public partial class Carousel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "id_padres",
                table: "padres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_detalle_cursoperiodo_asignatura",
                table: "detalle_cursoperiodo_asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_curso",
                table: "curso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_asignatura",
                table: "asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0)
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "carousel");

            migrationBuilder.AlterColumn<int>(
                name: "id_padres",
                table: "padres",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_detalle_cursoperiodo_asignatura",
                table: "detalle_cursoperiodo_asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_curso",
                table: "curso",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "id_asignatura",
                table: "asignatura",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("Relational:ColumnOrder", 0)
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ae745c4-32de-4d4b-b941-39315e76c62b",
                column: "ConcurrencyStamp",
                value: "10d1e6ff-dcd5-4fbe-9fab-d2543b09f4a9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4671823f-f30c-445c-8433-c9edb7d7caa8",
                column: "ConcurrencyStamp",
                value: "3bdf9e17-143b-456c-ab6a-4ae2a48fbb8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5042ce0-f40d-483e-8514-e014b145b4d9",
                column: "ConcurrencyStamp",
                value: "9749c088-e2c5-4e2d-b11d-710944427838");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29ce004f-6192-496b-a359-56bbbfd90ca1",
                columns: new[] { "ConcurrencyStamp", "fecha_agregado", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6a2eb33-3cac-448d-81d2-6af4ef468660", new DateTime(2021, 11, 4, 12, 36, 49, 664, DateTimeKind.Local).AddTicks(9682), "AQAAAAEAACcQAAAAEJTqXs83M5nto44xqRZ4vbDTwEbklhicYZVYUSxigeqv8McOxCZ6sJz3tz6qvwEYig==", "8eb6091f-ccca-47e9-8e23-4b52949238b8" });
        }
    }
}
