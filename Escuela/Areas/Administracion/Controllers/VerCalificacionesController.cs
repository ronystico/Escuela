using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class VerCalificacionesController : Controller
    {
        private readonly ILogger<VerCalificacionesController> _logger;
        private readonly ApplicationDbContext _data;

        public VerCalificacionesController(ApplicationDbContext data, ILogger<VerCalificacionesController> logger)
        {
            _data = data;
            _logger = logger;
        }

        public async Task<IActionResult> Inicio()
        {
            var detalleAsignaturas = await _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .AsNoTracking()
                .ToListAsync();

            return View(detalleAsignaturas);
        }

        public async Task<IActionResult> CalificacionesAsignatura(int id)
        {
            ViewBag.id = id;

            var detalleAsignaturas = await detalleCursoperiodoAsignaturasAsync(id);

            return View(detalleAsignaturas);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}