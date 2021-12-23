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
    public class CategoriaNoticiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaNoticiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaNoticia
        public async Task<IActionResult> Inicio()
        {
            return View(await _context.CategoriaNoticia.AsNoTracking().ToListAsync());
        }

        // GET: CategoriaNoticia/Agregar
        public IActionResult Agregar()
        {
            return View();
        }

        // POST: CategoriaNoticia/Agregar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Agregar([Bind("IdCategoriaNoticia,Nombre")] CategoriaNoticia categoriaNoticia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaNoticia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }
            return View(categoriaNoticia);
        }

        // GET: CategoriaNoticia/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaNoticia = await _context.CategoriaNoticia.FindAsync(id);
            if (categoriaNoticia == null)
            {
                return NotFound();
            }
            return View(categoriaNoticia);
        }

        // POST: CategoriaNoticia/Editar/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("IdCategoriaNoticia,Nombre")] CategoriaNoticia categoriaNoticia)
        {
            if (id != categoriaNoticia.IdCategoriaNoticia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaNoticia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaNoticiaExiste(categoriaNoticia.IdCategoriaNoticia))
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
            return View(categoriaNoticia);
        }

        // GET: CategoriaNoticia/Eliminar/5
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaNoticia = await _context.CategoriaNoticia
                .FirstOrDefaultAsync(m => m.IdCategoriaNoticia == id);
            if (categoriaNoticia == null)
            {
                return NotFound();
            }

            return View(categoriaNoticia);
        }

        // POST: CategoriaNoticia/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var categoriaNoticia = await _context.CategoriaNoticia.FindAsync(id);
            _context.CategoriaNoticia.Remove(categoriaNoticia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private bool CategoriaNoticiaExiste(int id)
        {
            return _context.CategoriaNoticia.Any(e => e.IdCategoriaNoticia == id);
        }
    }
}
