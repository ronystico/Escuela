using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Escuela.Services;
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
        public async Task<IActionResult> Inicio(int? numeroDePagina)
        {
            var noticias = _data.Noticia
            .Include(s => s.CategoriaNoticia)
            .Include(s => s.ApplicationUser)
            .AsNoTracking()
            .OrderByDescending(s => s.FechaPublicacion);

            int cantidadPorPagina = 4;

            return View(await PaginatedList<Noticia>.CreateAsync(noticias.AsNoTracking(), numeroDePagina ?? 1, cantidadPorPagina));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Detalles(int? id, int? numeroDePagina)
        {
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

            ViewBag.numerodepagina = numeroDePagina;

            return View(noticia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}