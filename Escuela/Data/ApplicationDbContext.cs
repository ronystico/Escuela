using Escuela.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escuela.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<DetalleEstudiante> DetalleEstudiante { get; set; }
        public DbSet<Padres> Padres { get; set; }
        public DbSet<Asignatura> Asignatura { get; set; }
        public DbSet<DetalleCursoperiodoAsignatura> DetalleCursoperiodoAsignatura { get; set; }
        public DbSet<DetalleProfesorCursoperiodoAsignatura> DetalleProfesorCursoperiodoAsignatura { get; set; }
        public DbSet<Periodo> Periodo { get; set; }
        public DbSet<DetalleCursoPeriodo> DetalleCursoPeriodo { get; set; }
        public DbSet<Calificacion> Calificacion { get; set; }
        public DbSet<Carousel> Carousel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DetalleCursoPeriodo>()
                .HasOne(c => c.Curso)
                .WithMany(ca => ca.DetalleCursoPeriodo)
                .HasForeignKey(ca => ca.IdCurso);

            modelBuilder.Entity<DetalleCursoPeriodo>()
                .HasOne(a => a.Periodo)
                .WithMany(ca => ca.DetalleCursoPeriodo)
                .HasForeignKey(ca => ca.IdPeriodo);

            modelBuilder.Entity<DetalleCursoperiodoAsignatura>()
                .HasOne(a => a.DetalleCursoPeriodo)
                .WithMany(au => au.DetalleCursoperiodoAsignatura)
                .HasForeignKey(au => au.IdDetalleCursoPeriodo);

            modelBuilder.Entity<DetalleCursoperiodoAsignatura>()
                .HasOne(p => p.Asignatura)
                .WithMany(pa => pa.DetalleCursoperiodoAsignatura)
                .HasForeignKey(pa => pa.IdAsignatura);

            modelBuilder.Entity<DetalleProfesorCursoperiodoAsignatura>()
            .HasOne(s => s.ApplicationUser)
            .WithMany(s => s.DetalleProfesorCursoperiodoAsignatura)
            .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<DetalleProfesorCursoperiodoAsignatura>()
            .HasOne(s => s.DetalleCursoperiodoAsignatura)
            .WithMany(s => s.DetalleProfesorCursoperiodoAsignatura)
            .HasForeignKey(s => s.IdDetalleCursoperiodoAsignatura);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "4671823f-f30c-445c-8433-c9edb7d7caa8",
                    Name = "Administracion",
                    NormalizedName = "Administracion".ToUpper()
                },
                new IdentityRole
                {
                    Id = "1ae745c4-32de-4d4b-b941-39315e76c62b",
                    Name = "Profesor",
                    NormalizedName = "Profesor".ToUpper()
                },
                new IdentityRole
                {
                    Id = "b5042ce0-f40d-483e-8514-e014b145b4d9",
                    Name = "Estudiante",
                    NormalizedName = "Estudiante".ToUpper()
                });

            modelBuilder.Entity<CategoriaNoticia>().HasData(
                new CategoriaNoticia{
                    IdCategoriaNoticia = 1,
                    Nombre = "General"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "29ce004f-6192-496b-a359-56bbbfd90ca1",
                    UserName = "administrador",
                    NormalizedUserName = "ADMINISTRADOR",
                    PasswordHash = hasher.HashPassword(null, "administrador1"),
                    PrimerApellido = "Administrando",
                    SegundoApellido = "Administración",
                    Nombres = "Administrador",
                    Estado = "Inscrito",
                    FechaAgregado = DateTime.Now
                }
            );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4671823f-f30c-445c-8433-c9edb7d7caa8",
                    UserId = "29ce004f-6192-496b-a359-56bbbfd90ca1"
                }
            );
        }
    }
}
