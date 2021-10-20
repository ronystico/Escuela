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

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class PadresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PadresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administracion/Padres
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.Padres.ToListAsync());
        }

        // GET: Administracion/Padres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padres = await _context.Padres.Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.ApplicationUser)
                .Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.Curso)
                .FirstOrDefaultAsync(m => m.IdPadres == id);
            if (padres == null)
            {
                return NotFound();
            }

            return View(padres);
        }

        // GET: Administracion/Padres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administracion/Padres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPadres,PrimerApellidoMadre,SegundoApellidoMadre,NombresMadre,TelefonoMadre,PrimerApellidoPadre,SegundoApellidoPadre,NombresPadre,TelefonoPadre")] Padres padres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padres);
        }

        // GET: Administracion/Padres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padres = await _context.Padres.FindAsync(id);
            if (padres == null)
            {
                return NotFound();
            }
            return View(padres);
        }

        // POST: Administracion/Padres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPadres,PrimerApellidoMadre,SegundoApellidoMadre,NombresMadre,TelefonoMadre,PrimerApellidoPadre,SegundoApellidoPadre,NombresPadre,TelefonoPadre")] Padres padres)
        {
            if (id != padres.IdPadres)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadresExists(padres.IdPadres))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(padres);
        }

        // GET: Administracion/Padres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padres = await _context.Padres
                .FirstOrDefaultAsync(m => m.IdPadres == id);
            if (padres == null)
            {
                return NotFound();
            }

            return View(padres);
        }

        // POST: Administracion/Padres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padres = await _context.Padres.FindAsync(id);
            _context.Padres.Remove(padres);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadresExists(int id)
        {
            return _context.Padres.Any(e => e.IdPadres == id);
        }
    }
}
