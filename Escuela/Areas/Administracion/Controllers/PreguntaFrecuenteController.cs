using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class PreguntaFrecuenteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PreguntaFrecuenteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PreguntaFrecuente
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.PreguntaFrecuente.ToListAsync());
        }

        // GET: PreguntaFrecuente/Agregar
        public IActionResult Agregar()
        {
            return View();
        }

        // POST: PreguntaFrecuente/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("IdPreguntaFrecuente,Pregunta,Respuesta")] PreguntaFrecuente preguntaFrecuente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preguntaFrecuente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(preguntaFrecuente);
        }

        // GET: PreguntaFrecuente/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntaFrecuente = await _context.PreguntaFrecuente.FindAsync(id);
            if (preguntaFrecuente == null)
            {
                return NotFound();
            }
            return View(preguntaFrecuente);
        }

        // POST: PreguntaFrecuente/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdPreguntaFrecuente,Pregunta,Respuesta")] PreguntaFrecuente preguntaFrecuente)
        {
            if (id != preguntaFrecuente.IdPreguntaFrecuente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntaFrecuente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreguntaFrecuenteExiste(preguntaFrecuente.IdPreguntaFrecuente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Inicio));
            }
            return View(preguntaFrecuente);
        }

        // GET: PreguntaFrecuente/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntaFrecuente = await _context.PreguntaFrecuente
                .FirstOrDefaultAsync(m => m.IdPreguntaFrecuente == id);
            if (preguntaFrecuente == null)
            {
                return NotFound();
            }

            return View(preguntaFrecuente);
        }

        // POST: PreguntaFrecuente/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var preguntaFrecuente = await _context.PreguntaFrecuente.FindAsync(id);
            _context.PreguntaFrecuente.Remove(preguntaFrecuente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool PreguntaFrecuenteExiste(int id)
        {
            return _context.PreguntaFrecuente.Any(e => e.IdPreguntaFrecuente == id);
        }
    }
}
