using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class AsignaturaController : Controller
    {
        private readonly ApplicationDbContext _data;

        public AsignaturaController(ApplicationDbContext data)
        {
            _data = data;
        }

        public IActionResult Inicio()
        {
            if (TempData.ContainsKey("Error"))
            {
                ViewBag.error = TempData["Error"].ToString();
            }
            var asignaturas = _data.Asignatura.AsNoTracking().ToList();
            return View(asignaturas);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                await _data.AddAsync(asignatura);
                _data.SaveChanges();
                return RedirectToAction(nameof(Inicio));
            }
            return View(asignatura);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var asignatura = await _data.Asignatura.FindAsync(id);
            return View(asignatura);
        }

        [HttpPost]
        public IActionResult Editar(Asignatura asignatura)
        {
            if (ModelState.IsValid)
            {
                _data.Asignatura.Update(asignatura);
                _data.SaveChanges();
                return RedirectToAction(nameof(Inicio));
            }
            return View(asignatura);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var asignatura = await _data.Asignatura.FindAsync(id);
            return View(asignatura);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var Asignatura = await _data.Asignatura.FindAsync(id);
            try
            {
                _data.Asignatura.Remove(Asignatura);
                _data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Imposible eliminar asignatura en uso. Se ha cancelado la eliminación.";
                return RedirectToAction(nameof(Inicio));
            }
            return RedirectToAction(nameof(Inicio));
        }
    }
}