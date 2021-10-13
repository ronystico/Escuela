using Escuela.Data;
using Escuela.Models;
using Escuela.Models.Interfaces;
using Escuela.Models.ViewModels;
using Escuela.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _data;

        public CursoController(ApplicationDbContext data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult Inicio()
        {
            var cursosasignatura = _data.Curso.Include(a => a.DetalleCursosAsignatura)
                .ThenInclude(a => a.Asignatura)
                .ToList();
            return View(cursosasignatura);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Curso curso)
        {
            if (ModelState.IsValid)
            {
                await _data.AddAsync(curso);
                _data.SaveChanges();
                return RedirectToAction("Inicio");
            }
            return View(curso);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var curso = await _data.Curso.FindAsync(id);

            ObtenerDatos datos = new ObtenerDatos(_data);
            ViewBag.asignaturas = datos.ObtenerAsignaturasCurso(id);

            var cursoasignatura = new CursoAsignaturaViewModel()
            {
                Curso = curso,
                DetalleCursosAsignatura = null
            };

            return View(cursoasignatura);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(CursoAsignaturaViewModel cursoAsignatura)
        {
            if (ModelState.IsValid)
            {
                var eliminarExistente = await _data.DetalleCursosAsignatura.Where(cu => cu.Curso.IdCurso == cursoAsignatura.Curso.IdCurso).ToListAsync();
                _data.RemoveRange(eliminarExistente);

                var asignaturas = new List<DetalleCursosAsignatura>();

                if(cursoAsignatura.AsignaturasSeleccionadas != null)
                {
                    foreach (var asignaturacurso in cursoAsignatura.AsignaturasSeleccionadas)
                    {
                        asignaturas.Add(new DetalleCursosAsignatura()
                        {
                            IdCurso = cursoAsignatura.Curso.IdCurso,
                            IdAsignatura = asignaturacurso
                        });
                    }
                    await _data.AddRangeAsync(asignaturas);
                }
                _data.Curso.Update(cursoAsignatura.Curso);
                await _data.SaveChangesAsync();
                return RedirectToAction("Inicio");
            }
            return View(cursoAsignatura);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var curso = await _data.Curso.FindAsync(id);
            return View(curso);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var Curso = await _data.Curso.FindAsync(id);
            _data.Curso.Remove(Curso);
            _data.SaveChanges();
            return RedirectToAction("Inicio");
        }
    }
}