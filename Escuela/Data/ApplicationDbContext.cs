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
        public DbSet<CategoriaNoticia> CategoriaNoticia { get; set; }
        public DbSet<Noticia> Noticia { get; set; }
        public DbSet<PreguntaFrecuente> PreguntaFrecuente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ONDELETE
            // No eliminar CursoPeriodoAsignatura si tiene calificaciones
            modelBuilder.Entity<Calificacion>()
            .HasOne(s => s.DetalleCursoperiodoAsignatura)
            .WithMany(s => s.Calificacion)
            .HasForeignKey(s => s.IdDetalleCursoPeriodoAsignatura)
            .OnDelete(DeleteBehavior.NoAction);

            // No eliminar CursoPeriodo si tiene estudiantes
            modelBuilder.Entity<DetalleEstudiante>()
           .HasOne(s => s.DetalleCursoPeriodo)
           .WithMany(s => s.DetalleEstudiante)
           .HasForeignKey(s => s.IdDetalleCursoPeriodo)
           .OnDelete(DeleteBehavior.NoAction);

            // No eliminar CategoriaNoticia si tiene noticias
            modelBuilder.Entity<Noticia>()
            .HasOne(s => s.CategoriaNoticia)
            .WithMany(s => s.Noticia)
            .HasForeignKey(s => s.IdCategoriaNoticia)
            .OnDelete(DeleteBehavior.NoAction);

            // Relaciones muchos a muchos
            // DetalleCursoPeriodo tiene un Curso, no eliminarlo
            modelBuilder.Entity<DetalleCursoPeriodo>()
                .HasOne(c => c.Curso)
                .WithMany(ca => ca.DetalleCursoPeriodo)
                .HasForeignKey(ca => ca.IdCurso)
                .OnDelete(DeleteBehavior.NoAction);

            // DetalleCursoPeriodo tiene un Periodo, no eliminarlo
            modelBuilder.Entity<DetalleCursoPeriodo>()
                .HasOne(a => a.Periodo)
                .WithMany(ca => ca.DetalleCursoPeriodo)
                .HasForeignKey(ca => ca.IdPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            // DetalleCursoperiodoAsignatura tiene un DetalleCursoPeriodo, no eliminarlo
            modelBuilder.Entity<DetalleCursoperiodoAsignatura>()
                .HasOne(a => a.DetalleCursoPeriodo)
                .WithMany(au => au.DetalleCursoperiodoAsignatura)
                .HasForeignKey(au => au.IdDetalleCursoPeriodo)
                .OnDelete(DeleteBehavior.NoAction);

            // DetalleCursoperiodoAsignatura tiene una Asignatura, no eliminarla
            modelBuilder.Entity<DetalleCursoperiodoAsignatura>()
                .HasOne(p => p.Asignatura)
                .WithMany(pa => pa.DetalleCursoperiodoAsignatura)
                .HasForeignKey(pa => pa.IdAsignatura)
                .OnDelete(DeleteBehavior.NoAction);

            // DetalleProfesorCursoperiodoAsignatura tiene un ApplicationUser
            modelBuilder.Entity<DetalleProfesorCursoperiodoAsignatura>()
            .HasOne(s => s.ApplicationUser)
            .WithMany(s => s.DetalleProfesorCursoperiodoAsignatura)
            .HasForeignKey(s => s.UserId);

            // DetalleProfesorCursoperiodoAsignatura tiene un DetalleCursoperiodoAsignatura
            modelBuilder.Entity<DetalleProfesorCursoperiodoAsignatura>()
            .HasOne(s => s.DetalleCursoperiodoAsignatura)
            .WithMany(s => s.DetalleProfesorCursoperiodoAsignatura)
            .HasForeignKey(s => s.IdDetalleCursoperiodoAsignatura);

            // Roles
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

            // Categoría por defecto
            modelBuilder.Entity<CategoriaNoticia>().HasData(
                new CategoriaNoticia
                {
                    IdCategoriaNoticia = 1,
                    Nombre = "General"
                }
            );
        }
    }
}
