﻿// <auto-generated />
using System;
using Escuela.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Escuela.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211104163651_DataAnnotationsFechas")]
    partial class DataAnnotationsFechas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Escuela.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("estado");

                    b.Property<DateTime>("FechaAgregado")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_agregado");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombres");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PrimerApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("primer_apellido");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SegundoApellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("segundo_apellido");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "29ce004f-6192-496b-a359-56bbbfd90ca1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a6a2eb33-3cac-448d-81d2-6af4ef468660",
                            EmailConfirmed = false,
                            Estado = "Inscrito",
                            FechaAgregado = new DateTime(2021, 11, 4, 12, 36, 49, 664, DateTimeKind.Local).AddTicks(9682),
                            LockoutEnabled = false,
                            Nombres = "Administrador",
                            NormalizedUserName = "ADMINISTRADOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEJTqXs83M5nto44xqRZ4vbDTwEbklhicYZVYUSxigeqv8McOxCZ6sJz3tz6qvwEYig==",
                            PhoneNumberConfirmed = false,
                            PrimerApellido = "Administrando",
                            SecurityStamp = "8eb6091f-ccca-47e9-8e23-4b52949238b8",
                            SegundoApellido = "Administración",
                            TwoFactorEnabled = false,
                            UserName = "administrador"
                        });
                });

            modelBuilder.Entity("Escuela.Models.Asignatura", b =>
                {
                    b.Property<int>("IdAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_asignatura")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.HasKey("IdAsignatura");

                    b.ToTable("asignatura");
                });

            modelBuilder.Entity("Escuela.Models.Calificacion", b =>
                {
                    b.Property<int>("IdCalificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_calificacion")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CalificacionTotal")
                        .HasColumnType("int")
                        .HasColumnName("calificacion_total");

                    b.Property<DateTime>("FechaAsignada")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_asignada");

                    b.Property<DateTime>("FechaEditada")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_editada");

                    b.Property<int>("IdDetalleCursoPeriodoAsignatura")
                        .HasColumnType("int")
                        .HasColumnName("id_detallecursoperiodo_asignatura");

                    b.Property<string>("IdEstudiante")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id_estudiante");

                    b.Property<string>("IdProfesor")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("id_profesor");

                    b.Property<string>("Observacion")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("observacion");

                    b.HasKey("IdCalificacion");

                    b.HasIndex("IdDetalleCursoPeriodoAsignatura");

                    b.HasIndex("IdEstudiante");

                    b.HasIndex("IdProfesor");

                    b.ToTable("calificacion");
                });

            modelBuilder.Entity("Escuela.Models.Curso", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_curso")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombre");

                    b.Property<string>("Seccion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("seccion");

                    b.HasKey("IdCurso");

                    b.ToTable("curso");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoPeriodo", b =>
                {
                    b.Property<int>("IdDetalleCursoPeriodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_curso_periodo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCurso")
                        .HasColumnType("int")
                        .HasColumnName("id_curso");

                    b.Property<int>("IdPeriodo")
                        .HasColumnType("int")
                        .HasColumnName("id_periodo");

                    b.HasKey("IdDetalleCursoPeriodo");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdPeriodo");

                    b.ToTable("detalle_curso_periodo");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoperiodoAsignatura", b =>
                {
                    b.Property<int>("IdDetalleCursoperiodoAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_cursoperiodo_asignatura")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdAsignatura")
                        .HasColumnType("int")
                        .HasColumnName("id_asignatura");

                    b.Property<int>("IdDetalleCursoPeriodo")
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_curso_periodo");

                    b.HasKey("IdDetalleCursoperiodoAsignatura");

                    b.HasIndex("IdAsignatura");

                    b.HasIndex("IdDetalleCursoPeriodo");

                    b.ToTable("detalle_cursoperiodo_asignatura");
                });

            modelBuilder.Entity("Escuela.Models.DetalleEstudiante", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdDetalleCursoPeriodo")
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_curso_periodo");

                    b.Property<int?>("IdPadres")
                        .HasColumnType("int")
                        .HasColumnName("id_padres");

                    b.Property<string>("IdoRNE")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)")
                        .HasColumnName("id_o_rne");

                    b.Property<int>("NumerodeOrden")
                        .HasColumnType("int")
                        .HasColumnName("numero_de_orden");

                    b.HasKey("UserId");

                    b.HasIndex("IdDetalleCursoPeriodo");

                    b.HasIndex("IdPadres");

                    b.ToTable("detalle_estudiante");
                });

            modelBuilder.Entity("Escuela.Models.DetalleProfesorCursoperiodoAsignatura", b =>
                {
                    b.Property<int>("IdDetalleProfesorCursoperiodoAsignatura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_profesor_cursoperiodo_asignatura")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDetalleCursoperiodoAsignatura")
                        .HasColumnType("int")
                        .HasColumnName("id_detalle_cursoperiodo_asignatura");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("UserId");

                    b.HasKey("IdDetalleProfesorCursoperiodoAsignatura");

                    b.HasIndex("IdDetalleCursoperiodoAsignatura");

                    b.HasIndex("UserId");

                    b.ToTable("detalle_profesor_cursoperiodo_asignatura");
                });

            modelBuilder.Entity("Escuela.Models.Padres", b =>
                {
                    b.Property<int>("IdPadres")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_padres")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombresMadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombres_madre");

                    b.Property<string>("NombresPadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("nombres_padre");

                    b.Property<string>("PrimerApellidoMadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("primer_apellido_madre");

                    b.Property<string>("PrimerApellidoPadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("primer_apellido_padre");

                    b.Property<string>("SegundoApellidoMadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("segundo_apellido_madre");

                    b.Property<string>("SegundoApellidoPadre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("segundo_apellido_padre");

                    b.Property<string>("TelefonoMadre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefono_madre");

                    b.Property<string>("TelefonoPadre")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("telefono_padre");

                    b.HasKey("IdPadres");

                    b.ToTable("padres");
                });

            modelBuilder.Entity("Escuela.Models.Periodo", b =>
                {
                    b.Property<int>("IdPeriodo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_periodo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_fin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("fecha_inicio");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("nombre");

                    b.Property<string>("Subperiodo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("subperiodo");

                    b.HasKey("IdPeriodo");

                    b.ToTable("periodo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "4671823f-f30c-445c-8433-c9edb7d7caa8",
                            ConcurrencyStamp = "3bdf9e17-143b-456c-ab6a-4ae2a48fbb8d",
                            Name = "Administracion",
                            NormalizedName = "ADMINISTRACION"
                        },
                        new
                        {
                            Id = "1ae745c4-32de-4d4b-b941-39315e76c62b",
                            ConcurrencyStamp = "10d1e6ff-dcd5-4fbe-9fab-d2543b09f4a9",
                            Name = "Profesor",
                            NormalizedName = "PROFESOR"
                        },
                        new
                        {
                            Id = "b5042ce0-f40d-483e-8514-e014b145b4d9",
                            ConcurrencyStamp = "9749c088-e2c5-4e2d-b11d-710944427838",
                            Name = "Estudiante",
                            NormalizedName = "ESTUDIANTE"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "29ce004f-6192-496b-a359-56bbbfd90ca1",
                            RoleId = "4671823f-f30c-445c-8433-c9edb7d7caa8"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Escuela.Models.Calificacion", b =>
                {
                    b.HasOne("Escuela.Models.DetalleCursoperiodoAsignatura", "DetalleCursoperiodoAsignatura")
                        .WithMany("Calificacion")
                        .HasForeignKey("IdDetalleCursoPeriodoAsignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.ApplicationUser", "ApplicationUserEstudiante")
                        .WithMany()
                        .HasForeignKey("IdEstudiante");

                    b.HasOne("Escuela.Models.ApplicationUser", "ApplicationUserProfesor")
                        .WithMany()
                        .HasForeignKey("IdProfesor");

                    b.Navigation("ApplicationUserEstudiante");

                    b.Navigation("ApplicationUserProfesor");

                    b.Navigation("DetalleCursoperiodoAsignatura");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoPeriodo", b =>
                {
                    b.HasOne("Escuela.Models.Curso", "Curso")
                        .WithMany("DetalleCursoPeriodo")
                        .HasForeignKey("IdCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.Periodo", "Periodo")
                        .WithMany("DetalleCursoPeriodo")
                        .HasForeignKey("IdPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Periodo");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoperiodoAsignatura", b =>
                {
                    b.HasOne("Escuela.Models.Asignatura", "Asignatura")
                        .WithMany("DetalleCursoperiodoAsignatura")
                        .HasForeignKey("IdAsignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.DetalleCursoPeriodo", "DetalleCursoPeriodo")
                        .WithMany("DetalleCursoperiodoAsignatura")
                        .HasForeignKey("IdDetalleCursoPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Asignatura");

                    b.Navigation("DetalleCursoPeriodo");
                });

            modelBuilder.Entity("Escuela.Models.DetalleEstudiante", b =>
                {
                    b.HasOne("Escuela.Models.DetalleCursoPeriodo", "DetalleCursoPeriodo")
                        .WithMany("DetalleEstudiante")
                        .HasForeignKey("IdDetalleCursoPeriodo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.Padres", "Padres")
                        .WithMany("DetalleEstudiante")
                        .HasForeignKey("IdPadres");

                    b.HasOne("Escuela.Models.ApplicationUser", "ApplicationUser")
                        .WithOne("DetalleEstudiante")
                        .HasForeignKey("Escuela.Models.DetalleEstudiante", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("DetalleCursoPeriodo");

                    b.Navigation("Padres");
                });

            modelBuilder.Entity("Escuela.Models.DetalleProfesorCursoperiodoAsignatura", b =>
                {
                    b.HasOne("Escuela.Models.DetalleCursoperiodoAsignatura", "DetalleCursoperiodoAsignatura")
                        .WithMany("DetalleProfesorCursoperiodoAsignatura")
                        .HasForeignKey("IdDetalleCursoperiodoAsignatura")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("DetalleProfesorCursoperiodoAsignatura")
                        .HasForeignKey("UserId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("DetalleCursoperiodoAsignatura");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Escuela.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Escuela.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Escuela.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Escuela.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Escuela.Models.ApplicationUser", b =>
                {
                    b.Navigation("DetalleEstudiante");

                    b.Navigation("DetalleProfesorCursoperiodoAsignatura");
                });

            modelBuilder.Entity("Escuela.Models.Asignatura", b =>
                {
                    b.Navigation("DetalleCursoperiodoAsignatura");
                });

            modelBuilder.Entity("Escuela.Models.Curso", b =>
                {
                    b.Navigation("DetalleCursoPeriodo");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoPeriodo", b =>
                {
                    b.Navigation("DetalleCursoperiodoAsignatura");

                    b.Navigation("DetalleEstudiante");
                });

            modelBuilder.Entity("Escuela.Models.DetalleCursoperiodoAsignatura", b =>
                {
                    b.Navigation("Calificacion");

                    b.Navigation("DetalleProfesorCursoperiodoAsignatura");
                });

            modelBuilder.Entity("Escuela.Models.Padres", b =>
                {
                    b.Navigation("DetalleEstudiante");
                });

            modelBuilder.Entity("Escuela.Models.Periodo", b =>
                {
                    b.Navigation("DetalleCursoPeriodo");
                });
#pragma warning restore 612, 618
        }
    }
}
