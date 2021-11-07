using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Escuela.Models.ViewModels;

namespace Escuela.Controllers
{
    [Area("Estudiante")]
    [Authorize(Roles = "Estudiante")]
    public class CalificacionesController : Controller
    {
        private readonly ApplicationDbContext _data;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public CalificacionesController(ApplicationDbContext data, SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _data = data;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Inicio()
        {
            var estudiante = _signInManager.Context.User.Identity.Name;
            var estudianteDetalles = await _userManager.FindByNameAsync(estudiante);

            var calificaciones = _data.Calificacion
            .Include(s => s.DetalleCursoperiodoAsignatura)
            .Where(s => s.IdEstudiante.Equals(estudianteDetalles.Id)).AsNoTracking()
            .ToListAsync();

            var idCursoPeriodoSinRepetir = new HashSet<int>();

            foreach(var calificacion in await calificaciones){
                if(!idCursoPeriodoSinRepetir.Contains(calificacion.DetalleCursoperiodoAsignatura.IdDetalleCursoPeriodo)){
                    idCursoPeriodoSinRepetir.Add(calificacion.DetalleCursoperiodoAsignatura.IdDetalleCursoPeriodo);
                }
            }

            List<DetalleCursoPeriodo> detalles = new List<DetalleCursoPeriodo>();

            foreach(var idCursoPeriodo in idCursoPeriodoSinRepetir){
                var cursoPeriodo = await _data.DetalleCursoPeriodo.FindAsync(idCursoPeriodo);
                _data.Entry(cursoPeriodo).Reference(s => s.Curso).Load();
                _data.Entry(cursoPeriodo).Reference(s => s.Periodo).Load();
                detalles.Add(cursoPeriodo);
            }

            return View(detalles);
        }

        public async Task<IActionResult> CalificacionPeriodoCurso(int id){
            if(id == 0){
                return NotFound();
            }

            ViewBag.id = id;
            
            var estudiante = _signInManager.Context.User.Identity.Name;
            var estudianteDetalles = await _userManager.FindByNameAsync(estudiante);

            ViewBag.id2 = estudianteDetalles.Id;

            var asignaturasCursoPeriodo = await _data.DetalleCursoperiodoAsignatura
            .Include(s => s.Asignatura)
            .Include(s => s.DetalleCursoPeriodo)
            .ThenInclude(s => s.Periodo)
            .Include(s => s.DetalleCursoPeriodo)
            .ThenInclude(s => s.Curso)
            .Where(s => s.IdDetalleCursoPeriodo == id)
            .AsNoTracking()
            .ToListAsync();

            var calificacionesEstudiante = await _data.Calificacion
            .Include(s => s.DetalleCursoperiodoAsignatura)
            .Include(s => s.ApplicationUserProfesor)
            .Where(s => s.IdEstudiante == estudianteDetalles.Id && s.DetalleCursoperiodoAsignatura.IdDetalleCursoPeriodo == id)
            .AsNoTracking()
            .ToListAsync();

            CalificacionPeriodoCursoViewModel calificacionesAsignaturasListas = new CalificacionPeriodoCursoViewModel(){
                DetalleCursoperiodoAsignatura = asignaturasCursoPeriodo,
                Calificacion = calificacionesEstudiante
            };

            return View(calificacionesAsignaturasListas);
        }
    }
}