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
    public class CursoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CursoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Curso
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.Curso.ToListAsync());
        }

        // GET: Curso/Agregar
        public IActionResult Agregar()
        {
            return View();
        }

        // POST: Curso/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("IdCurso,Nombre,Seccion")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(curso);
        }

        // GET: Curso/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Curso/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdCurso,Nombre,Seccion")] Curso curso)
        {
            if (id != curso.IdCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExiste(curso.IdCurso))
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
            return View(curso);
        }

        // GET: Curso/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.IdCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Curso/Delete/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            _context.Curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool CursoExiste(int id)
        {
            return _context.Curso.Any(e => e.IdCurso == id);
        }
    }
}
