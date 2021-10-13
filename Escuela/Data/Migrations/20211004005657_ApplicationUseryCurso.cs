using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Escuela.Data.Migrations
{
    public partial class ApplicationUseryCurso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "AspNetUsers",
                newName: "segundo_apellido");

            migrationBuilder.AddColumn<string>(
                name: "seccion",
                table: "curso",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "direccion",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "fecha_de_nacimiento",
                table: "AspNetUsers",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "nombres",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "primer_apellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "seccion",
                table: "curso");

            migrationBuilder.DropColumn(
                name: "direccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "fecha_de_nacimiento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "nombres",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "primer_apellido",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "segundo_apellido",
                table: "AspNetUsers",
                newName: "nombre");
        }
    }
}
