using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Escuela.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Escuela.Controllers
{
    [Area("Profesor")]
    [Authorize(Roles = "Profesor")]
    public class CalificacionController : Controller
    {
        private readonly ApplicationDbContext _data;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public CalificacionController(ApplicationDbContext data, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _data = data;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Inicio()
        {
            var usuario = _signInManager.Context.User.Identity.Name;
            var profesor = await _userManager.FindByNameAsync(usuario);
            _data.Entry(profesor).Collection(s => s.DetalleProfesorCursoperiodoAsignatura).Load();

            var asignaturas = new HashSet<int>(profesor.DetalleProfesorCursoperiodoAsignatura.Select(s => s.IdDetalleCursoperiodoAsignatura));

            var detalleAsignaturas = await _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .ToListAsync();

            var asignaturasProfesor = new List<CalificacionInicioViewModel>();

            foreach (var asignatura in detalleAsignaturas)
            {
                foreach (var asignaturaProfesor in asignaturas)
                {
                    if (asignaturaProfesor == asignatura.IdDetalleCursoperiodoAsignatura)
                    {
                        asignaturasProfesor.Add(new CalificacionInicioViewModel
                        {
                            IDAsignatura = asignatura.IdDetalleCursoperiodoAsignatura,
                            NombrePeriodoSubperiodo = asignatura.DetalleCursoPeriodo.Periodo.Nombre + " / " + asignatura.DetalleCursoPeriodo.Periodo.Subperiodo,
                            NombreCursoSeccion = asignatura.DetalleCursoPeriodo.Curso.Nombre + " / " + asignatura.DetalleCursoPeriodo.Curso.Seccion,
                            NombreAsignatura = asignatura.Asignatura.Nombre
                        });
                    }
                }
            }

            return View(asignaturasProfesor);
        }

        public async Task<IActionResult> CalificacionesAsignatura(int id)
        {
            ViewBag.id = id;

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasAsync(id);

            return View(detalleAsignaturas);
        }

        public async Task<IActionResult> AgregarCalificacion(int id, string id2)
        {
            if (id == 0 || id2 == null)
            {
                return NotFound();
            }
            
            ViewBag.id = id;
            ViewBag.id2 = id2;

            if (_data.Calificacion.Any(s => s.IdDetalleCursoPeriodoAsignatura == id
             && s.IdEstudiante == id2))
            {
                return RedirectToAction("CalificacionesAsignatura", new { id = id });
            }
            var detalleAsignaturas = await detalleCursoperiodoAsignaturasEstudianteAsync(id, id2);
            var detallesListos = new AgregarEditarCalificacionViewModel
            {
                DetalleCursoperiodoAsignatura = detalleAsignaturas,
                Calificacion = new Calificacion()
            };

            return View(detallesListos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarCalificacion(Calificacion calificacion, int id, string id2)
        {
            if (id == 0 || id2 == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            ViewBag.id2 = id2;

            if (ModelState.IsValid)
            {
                if (_data.Calificacion.Any(s => s.IdDetalleCursoPeriodoAsignatura == id
             && s.IdEstudiante == id2))
                {
                    return RedirectToAction("CalificacionesAsignatura", new { id = id });
                }
                else
                {
                    var usuario = _signInManager.Context.User.Identity.Name;
                    var profesor = await _userManager.FindByNameAsync(usuario);

                    var calificacionNueva = new Calificacion
                    {
                        IdEstudiante = calificacion.IdEstudiante,
                        IdProfesor = profesor.Id,
                        IdDetalleCursoPeriodoAsignatura = calificacion.IdDetalleCursoPeriodoAsignatura,
                        FechaAsignada = DateTime.Now,
                        CalificacionTotal = calificacion.CalificacionTotal,
                        Observacion = calificacion.Observacion,
                        FechaEditada = DateTime.Now
                    };

                    await _data.Calificacion.AddAsync(calificacionNueva);
                    await _data.SaveChangesAsync();
                    return RedirectToAction("CalificacionesAsignatura", new { id = calificacion.IdDetalleCursoPeriodoAsignatura });
                }
            }

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasEstudianteAsync(id, id2);
            var detallesListos = new AgregarEditarCalificacionViewModel
            {
                DetalleCursoperiodoAsignatura = detalleAsignaturas,
                Calificacion = new Calificacion()
            };

            return View(detallesListos);
        }

        public async Task<IActionResult> EditarCalificacion(int id, string id2)
        {
            if (id == 0 || id2 == null)
            {
                return NotFound();
            }

            if (!_data.Calificacion.Any(s => s.IdDetalleCursoPeriodoAsignatura == id
             && s.IdEstudiante == id2))
            {
                return RedirectToAction("CalificacionesAsignatura", new { id = id });
            }

            ViewBag.id = id;
            ViewBag.id2 = id2;

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasEstudianteAsync(id, id2);
            var detallesListos = new AgregarEditarCalificacionViewModel
            {
                DetalleCursoperiodoAsignatura = detalleAsignaturas,
                Calificacion = new Calificacion()
            };

            return View(detallesListos);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCalificacion(Calificacion calificacion, int id, string id2)
        {
            if (id == 0 || id2 == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            ViewBag.id2 = id2;

            if (ModelState.IsValid)
            {
                if (_data.Calificacion.Any(s => s.IdDetalleCursoPeriodoAsignatura == calificacion.IdDetalleCursoPeriodoAsignatura
             && s.IdEstudiante == calificacion.IdEstudiante))
                {
                    var calificacionActual = await _data.Calificacion.Where(s => s.IdDetalleCursoPeriodoAsignatura == calificacion.IdDetalleCursoPeriodoAsignatura
                && s.IdEstudiante == calificacion.IdEstudiante).FirstOrDefaultAsync();

                    var usuario = _signInManager.Context.User.Identity.Name;
                    var profesor = await _userManager.FindByNameAsync(usuario);

                    calificacionActual.IdProfesor = profesor.Id;
                    calificacionActual.CalificacionTotal = calificacion.CalificacionTotal;
                    calificacionActual.Observacion = calificacion.Observacion;
                    calificacionActual.FechaEditada = DateTime.Now;

                    _data.Calificacion.Update(calificacionActual);
                    await _data.SaveChangesAsync();
                    return RedirectToAction("CalificacionesAsignatura", new { id = calificacion.IdDetalleCursoPeriodoAsignatura });
                }
                else
                {
                    return RedirectToAction("CalificacionesAsignatura", new { id = calificacion.IdDetalleCursoPeriodoAsignatura });
                }
            }

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasEstudianteAsync(id, id2);
            var detallesListos = new AgregarEditarCalificacionViewModel
            {
                DetalleCursoperiodoAsignatura = detalleAsignaturas,
                Calificacion = new Calificacion()
            };

            return View(detallesListos);
        }

        public async Task<IActionResult> AgregarEditarCalificacionesAsignatura(int id)
        {
            ViewBag.id = id;

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasAsync(id);
            var detallesListos = new AgregarEditarCalificacionesViewModel
            {
                DetalleCursoperiodoAsignatura = detalleAsignaturas,
                Calificacion = new List<Calificacion>(){
                    new Calificacion{

                    }
                }
            };

            return View(detallesListos);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEditarCalificacionesAsignatura(int id, AgregarEditarCalificacionesViewModel klkylodato2)
        {
            ViewBag.id = id;

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasAsync(id);

            return View(detalleAsignaturas);
        }

        private async Task<List<DetalleCursoperiodoAsignatura>> detalleCursoperiodoAsync(int id)
        {
            return await _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Where(s => s.IdDetalleCursoperiodoAsignatura == id)
                .ToListAsync();
        }

        private async Task<List<DetalleCursoperiodoAsignatura>> detalleCursoperiodoAsignaturasAsync(int id)
        {
            return await _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.DetalleEstudiante)
                .ThenInclude(s => s.ApplicationUser)
                .Include(s => s.Calificacion)
                .ThenInclude(s => s.ApplicationUserEstudiante)
                .ThenInclude(s => s.DetalleEstudiante)
                .Include(s => s.Calificacion)
                .ThenInclude(s => s.ApplicationUserProfesor)
                .Where(s => s.IdDetalleCursoperiodoAsignatura == id)
                .ToListAsync();
        }

        private async Task<List<DetalleCursoperiodoAsignatura>> detalleCursoperiodoAsignaturasEstudianteAsync(int id, string id2)
        {
            return await _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.DetalleEstudiante.Where(s => s.UserId == id2))
                .ThenInclude(s => s.ApplicationUser)
                .Include(s => s.Calificacion.Where(s => s.IdEstudiante == id2))
                .ThenInclude(s => s.ApplicationUserEstudiante)
                .ThenInclude(s => s.DetalleEstudiante)
                .Include(s => s.Calificacion.Where(s => s.IdEstudiante == id2))
                .ThenInclude(s => s.ApplicationUserProfesor)
                .Where(s => s.IdDetalleCursoperiodoAsignatura == id)
                .ToListAsync();
        }
    }
}
