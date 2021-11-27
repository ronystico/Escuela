using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escuela.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly ILogger<NoticiasController> _logger;
        private readonly ApplicationDbContext _data;

        public NoticiasController(ApplicationDbContext data, ILogger<NoticiasController> logger)
        {
            _data = data;
            _logger = logger;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Inicio()
        {
            var noticias = await _data.Noticia
            .Include(s => s.CategoriaNoticia)
            .Include(s => s.ApplicationUser)
            .AsNoTracking()
            .OrderByDescending(s => s.FechaPublicacion)
            .ToListAsync();
            return View(noticias);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalles(int? id){
            if(id == null){
                return NotFound();
            }
            var noticia = await _data.Noticia
            .Include(s => s.CategoriaNoticia)
            .Include(s => s.ApplicationUser)
            .Where(s => s.IdNoticia == id)
            .AsNoTracking()
            .FirstOrDefaultAsync();
            if(noticia == null){
                return NotFound();
            }

            return View(noticia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}