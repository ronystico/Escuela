using Escuela.Data;
using Escuela.Models;
using Escuela.Models.ViewModels;
using Escuela.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class CursoPeriodoAsignaturaController : Controller
    {
        private readonly ApplicationDbContext _data;

        public CursoPeriodoAsignaturaController(ApplicationDbContext data)
        {
            _data = data;
        }

        [HttpGet]
        public IActionResult Inicio()
        {
            var cursosasignatura = _data.DetalleCursoPeriodo.Include(a => a.Curso)
                .Include(a => a.Periodo)
                .Include(s => s.DetalleCursoperiodoAsignatura)
                .ThenInclude(s => s.Asignatura)
                .ToList();
            return View(cursosasignatura);
        }

        [HttpGet]
        public IActionResult Agregar()
        {
            ObtenerCursosySecciones();
            ObtenerPeriodosySubperiodos();
            ObtenerAsignaturas();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(AgregarCursoPeriodoViewModel cursoPeriodo)
        {
            if (ModelState.IsValid)
            {
                if (_data.DetalleCursoPeriodo.Any(s => s.IdCurso == cursoPeriodo.IdCurso && s.IdPeriodo == cursoPeriodo.IdPeriodo))
                {
                    ModelState.AddModelError(string.Empty, "Esta combinaci�n de Periodo/Curso ya existe, debes editarla");
                    ObtenerCursosySecciones();
                    ObtenerPeriodosySubperiodos();
                    ObtenerAsignaturas();
                    return View(cursoPeriodo);
                }

                var asignaturas = new List<DetalleCursoperiodoAsignatura>();

                var cursoPeriodoAgregado = new DetalleCursoPeriodo
                {
                    IdCurso = cursoPeriodo.IdCurso,
                    IdPeriodo = cursoPeriodo.IdPeriodo
                };
                await _data.DetalleCursoPeriodo.AddAsync(cursoPeriodo);
                var resultado = await _data.SaveChangesAsync();

                if (cursoPeriodo.AsignaturasSeleccionadas != null && resultado != 0)
                {
                    foreach (var asignatura in cursoPeriodo.AsignaturasSeleccionadas)
                    {
                        asignaturas.Add(new DetalleCursoperiodoAsignatura
                        {
                            IdDetalleCursoPeriodo = cursoPeriodo.IdDetalleCursoPeriodo,
                            IdAsignatura = asignatura,
                        });
                    }
                    _data.AddRange(asignaturas);
                    await _data.SaveChangesAsync();
                }
                return RedirectToAction("Inicio");
            }
            ObtenerCursosySecciones();
            ObtenerPeriodosySubperiodos();
            ObtenerAsignaturas();

            return View(cursoPeriodo);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cursoPeriodo = await _data.DetalleCursoPeriodo.Include(s => s.Curso).Include(s => s.Periodo)
                .Include(s => s.DetalleCursoperiodoAsignatura).ThenInclude(s => s.Asignatura).AsNoTracking()
                .FirstOrDefaultAsync(s => s.IdDetalleCursoPeriodo == id);
            if (cursoPeriodo == null)
            {
                return NotFound();
            }
            EditarAsignaturas(cursoPeriodo);

            return View(cursoPeriodo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, CursoPeriodoAsignaturaViewModel cursoPeriodoAsignatura)
        {
            if (ModelState.IsValid)
            {
                var eliminarExistente = await _data.DetalleCursoperiodoAsignatura.Where(cu => cu.IdDetalleCursoPeriodo == id).ToListAsync();

                _data.RemoveRange(eliminarExistente);

                var asignaturas = new List<DetalleCursoperiodoAsignatura>();

                if (cursoPeriodoAsignatura.AsignaturasSeleccionadas != null)
                {
                    foreach (var asignaturacurso in cursoPeriodoAsignatura.AsignaturasSeleccionadas)
                    {
                        asignaturas.Add(new DetalleCursoperiodoAsignatura()
                        {
                            IdDetalleCursoPeriodo = id,
                            IdAsignatura = asignaturacurso
                        });
                    }
                    await _data.AddRangeAsync(asignaturas);
                }
                await _data.SaveChangesAsync();
                return RedirectToAction("Inicio");
            }
            return View(cursoPeriodoAsignatura);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            var cursoPeriodo = _data.DetalleCursoPeriodo.Single(s => s.IdDetalleCursoPeriodo == id);
            if (cursoPeriodo == null)
            {
                return NotFound();
            }
            _data.Entry(cursoPeriodo).Reference(s => s.Curso).Load();
            _data.Entry(cursoPeriodo).Reference(s => s.Periodo).Load();
            return View(cursoPeriodo);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var detalleCursoPeriodo = await _data.DetalleCursoPeriodo.FindAsync(id);
            if (detalleCursoPeriodo == null)
            {
                return NotFound();
            }
            _data.DetalleCursoPeriodo.Remove(detalleCursoPeriodo);
            _data.SaveChanges();
            return RedirectToAction("Inicio");
        }

        public async Task<IActionResult> VerEstudiantes(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            if (!_data.DetalleCursoPeriodo.Any(s => s.IdDetalleCursoPeriodo == id))
            {
                return NotFound();
            }
            var estudiantesCursoPeriodo = await _data.DetalleCursoPeriodo
            .Include(s => s.DetalleEstudiante)
            .ThenInclude(s => s.ApplicationUser)
            .Where(s => s.IdDetalleCursoPeriodo == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();

            return View(estudiantesCursoPeriodo);
        }

        public async Task<IActionResult> RevocarAsignaturas(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            if (!_data.DetalleCursoPeriodo.Any(s => s.IdDetalleCursoPeriodo == id))
            {
                return NotFound();
            }

            var cursosasignatura = await _data.DetalleCursoPeriodo.Include(a => a.Curso)
                .Include(a => a.Periodo)
                .Include(s => s.DetalleCursoperiodoAsignatura)
                .ThenInclude(s => s.Asignatura)
                .Where(s => s.IdDetalleCursoPeriodo == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            return View(cursosasignatura);
        }

        [HttpPost, ActionName("RevocarAsignaturas")]
        public async Task<IActionResult> RevocarAsignaturasConfirmado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var detalleCursoPeriodo = await _data.DetalleCursoPeriodo.FindAsync(id);
            if (detalleCursoPeriodo == null)
            {
                return NotFound();
            }

            var cursosasignatura = await _data.DetalleCursoPeriodo
                .Include(s => s.DetalleCursoperiodoAsignatura)
                .Where(s => s.IdDetalleCursoPeriodo == id)
                .FirstOrDefaultAsync();

            HashSet<int> asignaturasEliminar;
            if (cursosasignatura.DetalleCursoperiodoAsignatura.Count > 0)
            {
                asignaturasEliminar = new HashSet<int>(
                    cursosasignatura.DetalleCursoperiodoAsignatura
                    .Select(s => s.IdDetalleCursoperiodoAsignatura));
            }
            else
            {
                return RedirectToAction("Inicio");
            }

            List<DetalleProfesorCursoperiodoAsignatura> seleccionarAsignaturaProfesor =
            new List<DetalleProfesorCursoperiodoAsignatura>();
            foreach (var item in asignaturasEliminar)
            {
                if (_data.DetalleProfesorCursoperiodoAsignatura
                    .Any(s => s.IdDetalleCursoperiodoAsignatura == item))
                {
                    seleccionarAsignaturaProfesor.Add(
                await _data.DetalleProfesorCursoperiodoAsignatura
                .Where(s => s.IdDetalleCursoperiodoAsignatura == item).FirstOrDefaultAsync());
                }
            }
            if (seleccionarAsignaturaProfesor.Count > 0)
            {
                _data.DetalleProfesorCursoperiodoAsignatura.RemoveRange(seleccionarAsignaturaProfesor);
                await _data.SaveChangesAsync();
            }

            return RedirectToAction("Inicio");
        }

        public IActionResult MoverEstudiantes(int id)
        {
            return View();
        }

        // Obtener Cursos y Secciones
        private void ObtenerCursosySecciones(object cursoSeleccionado = null)
        {
            var cursosObtenidos = _data.Curso.OrderBy(s => s.Nombre)
                .Select(s => new { ID = s.IdCurso, NombreSeccion = s.Nombre + " / " + s.Seccion });
            ViewBag.cursos = new SelectList(cursosObtenidos.AsNoTracking(), "ID", "NombreSeccion", cursoSeleccionado);
        }

        // Obtener Periodos y Subperiodos
        private void ObtenerPeriodosySubperiodos(object periodoSeleccionado = null)
        {
            var periodosObtenidos = _data.Periodo.OrderBy(s => s.Nombre)
                .Select(s => new { ID = s.IdPeriodo, NombreSubperiodo = s.Nombre + " / " + s.Subperiodo });
            ViewBag.periodos = new SelectList(periodosObtenidos.AsNoTracking(), "ID", "NombreSubperiodo", periodoSeleccionado);
        }

        // Obtener Asignaturas
        private void ObtenerAsignaturas(object asignaturaSeleccionada = null)
        {
            var asignaturas = _data.Asignatura.OrderBy(s => s.Nombre)
                .Select(s => new { ID = s.IdAsignatura, Nombre = s.Nombre });
            ViewBag.asignaturas = new SelectList(asignaturas, "ID", "Nombre", asignaturaSeleccionada);
        }

        // Editar Asignaturas
        private void EditarAsignaturas(DetalleCursoPeriodo cursoPeriodo)
        {
            var asignaturasObtenidas = _data.Asignatura;
            var asignaturasPeriodo = new HashSet<int>(cursoPeriodo.DetalleCursoperiodoAsignatura.Select(s => s.IdAsignatura));
            var viewModel = new List<AgregarCursoPeriodoViewModel>();
            foreach (var asignatura in asignaturasObtenidas)
            {
                viewModel.Add(new AgregarCursoPeriodoViewModel
                {
                    IdAsignatura = asignatura.IdAsignatura,
                    NombreAsignatura = asignatura.Nombre,
                    Seleccionado = asignaturasPeriodo.Contains(asignatura.IdAsignatura)
                });
            }
            ViewData["Asignaturas"] = viewModel;
        }
    }
}