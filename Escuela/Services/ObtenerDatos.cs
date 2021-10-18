using System.Collections.Generic;
using System.Linq;
using Escuela.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escuela.Models;
using Escuela.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Escuela.Services
{
    public class ObtenerDatos
    {
        private readonly ApplicationDbContext _data;
        public ObtenerDatos(ApplicationDbContext data)
        {
            _data = data;
        }

        public List<SelectListItem> ObtenerRoles(){
            List<IdentityRole> roles = _data.Roles.ToList();
            List<SelectListItem> selectroles = new List<SelectListItem>();
            foreach (var role in roles)
            {
                if (role.Name.Equals("Estudiante"))
                {
                    selectroles.Add(new SelectListItem { Value = role.Name, Text = role.Name, Selected = true });
                }
                else
                {
                    selectroles.Add(new SelectListItem { Value = role.Name, Text = role.Name });
                }
            }
            selectroles.Sort((a, b) => string.Compare(a.Text, b.Text));

            return selectroles;
        }

        public List<Curso> ObtenerCursos(){
            return _data.Curso.ToList();
        }

        public List<SelectListItem> ObtenerCursosEstudiante(string id)
        {
            var estudiante = _data.DetalleEstudiante.Where(s => s.UserId == id).FirstOrDefault();
            var cursos = _data.Curso.ToList();
            var cursosSelectListItem = new List<SelectListItem>();
            foreach(var curso in cursos)
            {
                if (curso.IdCurso.ToString().Equals(estudiante.UserId))
                {
                    cursosSelectListItem.Add(new SelectListItem
                    {
                        Value = curso.IdCurso.ToString(),
                        Text = curso.Nombre + " " + curso.Seccion,
                        Selected = true
                    });
                }
                else
                {
                    cursosSelectListItem.Add(new SelectListItem
                    {
                        Value = curso.IdCurso.ToString(),
                        Text = curso.Nombre + " " + curso.Seccion,
                    });
                }
            }
            return cursosSelectListItem;
        }

        public List<CursoAsignaturaViewModel> ObtenerCursoconAsignaturas()
        {
            return (from curso in _data.Curso.ToList()
                    join asignaturacurso in _data.DetalleCursosAsignatura.Include(a => a.Asignatura)
                    .ToList()

                    on curso.IdCurso equals asignaturacurso.IdCurso into ac
                    from cursoac in ac.DefaultIfEmpty()
                    select new CursoAsignaturaViewModel
                    {
                        Curso = curso,
                        DetalleCursosAsignatura = cursoac,
                    })
                    .ToList();
        }

        public List<SelectListItem> ObtenerAsignaturas()
        {
            var buscarasignaturas = _data.Asignatura.ToList();
            List<SelectListItem> asignaturas = new List<SelectListItem>();
            foreach(var asignatura in buscarasignaturas)
            {
                asignaturas.Add(new SelectListItem { Value = asignatura.IdAsignatura.ToString(), Text = asignatura.Nombre });
            }
            return asignaturas;
        }

        public List<SelectListItem> ObtenerAsignaturasCurso(int id)
        {
            var cursosasignatura = _data.Asignatura.Include(a => a.DetalleCursosAsignatura)
                .ThenInclude(a => a.Curso)
                .ToList();
            List<SelectListItem> asignaturascurso = new List<SelectListItem>();

            foreach(var asignatura in cursosasignatura)
            {
                foreach(var asignaturacurso in asignatura.DetalleCursosAsignatura)
                {
                    if (asignaturacurso.IdCurso == id)
                    {
                        asignaturascurso.Add(new SelectListItem
                        {
                            Value = asignatura.IdAsignatura.ToString(),
                            Text = asignatura.Nombre,
                            Selected = true
                        });
                    }
                }
                if(!asignaturascurso.Any(a => a.Value.Equals(asignatura.IdAsignatura.ToString())))
                {
                    asignaturascurso.Add(new SelectListItem
                    {
                        Value = asignatura.IdAsignatura.ToString(),
                        Text = asignatura.Nombre,
                    });
                }
                
            }
            return asignaturascurso;
        }

        public List<SelectListItem> ObtenerDetalleCursosAsignaturas()
        {
            var buscarCursosAsignaturas = _data.DetalleCursosAsignatura.Include(a => a.Asignatura)
                .Include(a => a.Curso).ToList();
            List<SelectListItem> CursosAsignaturas = new List<SelectListItem>();
            foreach (var cursoAsignatura in buscarCursosAsignaturas)
            {
                CursosAsignaturas.Add(new SelectListItem { Value = cursoAsignatura.IdDetalleCursosAsignatura.ToString(),
                    Text = cursoAsignatura.Curso.Nombre + " " + cursoAsignatura.Curso.Seccion + " - " + cursoAsignatura.Asignatura.Nombre });
            }
            return CursosAsignaturas;
        }
    }
}