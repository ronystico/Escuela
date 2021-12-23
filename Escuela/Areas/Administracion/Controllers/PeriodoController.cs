using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;

namespace Escuela.Views
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class PeriodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PeriodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Periodo
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.Periodo.AsNoTracking().ToListAsync());
        }

        // GET: Periodo/Agregar
        public IActionResult Agregar()
        {
            return View();
        }

        // POST: Periodo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("IdPeriodo,Nombre,Subperiodo,FechaInicio,FechaFin")] Periodo periodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(periodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio)); ;
            }
            return View(periodo);
        }

        // GET: Periodo/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo.FindAsync(id);
            if (periodo == null)
            {
                return NotFound();
            }
            return View(periodo);
        }

        // POST: Periodo/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdPeriodo,Nombre,Subperiodo,FechaInicio,FechaFin")] Periodo periodo)
        {
            if (id != periodo.IdPeriodo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(periodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodoExiste(periodo.IdPeriodo))
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
            return View(periodo);
        }

        // GET: Periodo/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var periodo = await _context.Periodo
                .FirstOrDefaultAsync(m => m.IdPeriodo == id);
            if (periodo == null)
            {
                return NotFound();
            }

            return View(periodo);
        }

        // POST: Periodo/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var periodo = await _context.Periodo.FindAsync(id);
            _context.Periodo.Remove(periodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool PeriodoExiste(int id)
        {
            return _context.Periodo.Any(e => e.IdPeriodo == id);
        }
    }
}
