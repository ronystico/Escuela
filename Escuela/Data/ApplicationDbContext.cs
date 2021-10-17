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
        public DbSet<DetalleCursosAsignatura> DetalleCursosAsignatura { get; set; }
        public DbSet<DetalleProfesorCursosAsignatura> DetalleProfesorCursosAsignatura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DetalleCursosAsignatura>()
                .HasOne(c => c.Curso)
                .WithMany(ca => ca.DetalleCursosAsignatura)
                .HasForeignKey(ca => ca.IdCurso);

            modelBuilder.Entity<DetalleCursosAsignatura>()
                .HasOne(a => a.Asignatura)
                .WithMany(ca => ca.DetalleCursosAsignatura)
                .HasForeignKey(ca => ca.IdAsignatura);

            modelBuilder.Entity<DetalleProfesorCursosAsignatura>()
                .HasOne(a => a.ApplicationUser)
                .WithMany(au => au.DetalleProfesorCursosAsignatura)
                .HasForeignKey(au => au.UserId);

            modelBuilder.Entity<DetalleProfesorCursosAsignatura>()
                .HasOne(p => p.DetalleCursosAsignatura)
                .WithMany(pa => pa.DetalleProfesorCursosAsignatura)
                .HasForeignKey(pa => pa.IdDetalleCursosAsignatura);

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

            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "29ce004f-6192-496b-a359-56bbbfd90ca1",
                    UserName = "klkcompay@dominican.com",
                    NormalizedUserName = "KLKCOMPAY@DOMINICAN.COM",
                    PasswordHash = hasher.HashPassword(null, "csUZdHdbnY4ts7j"),
                    PrimerApellido = "Dominicano",
                    SegundoApellido = "Soy",
                    Nombres = "Klk Compay",
                    Estado = "Inscrito"
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
