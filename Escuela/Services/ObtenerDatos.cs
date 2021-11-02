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

        // En Agregar Usuario, muestra el rol estudiante por defecto
        // ya que es un rol común
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

        // Obtiene los Periodos y los coloca en un SelectListItem
        public List<SelectListItem> ObtenerPeriodosySubperiodos()
        {
            return _data.Periodo.Select(s => new SelectListItem
            {
                Value = s.IdPeriodo.ToString(),
                Text = s.Nombre + " / " + s.Subperiodo
            }).ToList();
        }

        // Obtiene las asignaturas y las coloca en un SelectListItem
        public List<SelectListItem> ObtenerAsignaturas()
        {
            return _data.Asignatura.Select(s => new SelectListItem
            {
                Value = s.IdAsignatura.ToString(),
                Text = s.Nombre
            }).ToList();
        }

        // TODO: Obtiene el Curso/Periodo actual del estudiante en EditarEstudiante
        public List<SelectListItem> ObtenerCursoPeriodoEstudiante(string id)
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

        public List<SelectListItem> ObtenerAsignaturasCurso(int id)
        {
            var cursosasignatura = _data.Asignatura.Include(a => a.DetalleCursoperiodoAsignatura)
                .ThenInclude(a => a.Asignatura)
                .ToList();
            List<SelectListItem> asignaturascurso = new List<SelectListItem>();

            foreach(var asignatura in cursosasignatura)
            {
                foreach(var asignaturacurso in asignatura.DetalleCursoperiodoAsignatura)
                {
                    if (asignaturacurso.IdDetalleCursoPeriodo == id)
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
    }
}