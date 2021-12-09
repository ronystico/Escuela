using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Escuela.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class NoticiaController : Controller
    {
        private readonly ILogger<NoticiaController> _logger;
        private readonly ApplicationDbContext _data;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public NoticiaController(ApplicationDbContext data,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ILogger<NoticiaController> logger)
        {
            _data = data;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Inicio()
        {
            var noticias = _data.Noticia
            .Include(s => s.CategoriaNoticia)
            .Include(s => s.ApplicationUser)
            .AsNoTracking()
            .OrderByDescending(s => s.FechaPublicacion)
            .ToList();
            return View(noticias);
        }

        public IActionResult Agregar()
        {
            ObtenerCategorias();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(Noticia noticia)
        {
            if (ModelState.IsValid)
            {
                var usuario = _signInManager.Context.User.Identity.Name;
                var administrador = await _userManager.FindByNameAsync(usuario);

                noticia.IdAutor = administrador.Id;
                noticia.FechaPublicacion = DateTime.Now;
                noticia.FechaEdicion = DateTime.Now;

                await _data.Noticia.AddAsync(noticia);
                await _data.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }

            ObtenerCategorias();
            return View(noticia);
        }

        public async Task<IActionResult> Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var noticia = await _data.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            ObtenerCategorias();
            return View(noticia);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Noticia noticiaRecibida)
        {
            if (id == 0)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var noticia = await _data.Noticia.FindAsync(id);
                if (noticia == null)
                {
                    return NotFound();
                }
                noticia.IdCategoriaNoticia = noticiaRecibida.IdCategoriaNoticia;
                noticia.Titulo = noticiaRecibida.Titulo;
                noticia.Cuerpo = noticiaRecibida.Cuerpo;
                noticia.FechaEdicion = DateTime.Now;
                
                _data.Noticia.Update(noticia);
                await _data.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }

            ObtenerCategorias();
            return View(noticiaRecibida);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var noticia = await _data.Noticia.FindAsync(id);
            await _data.Entry(noticia).Reference(s => s.CategoriaNoticia).LoadAsync();
            await _data.Entry(noticia).Reference(s => s.ApplicationUser).LoadAsync();
            if (noticia == null)
            {
                return NotFound();
            }
            return View(noticia);
        }

        [HttpPost,ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var noticia = await _data.Noticia.FindAsync(id);
            if (noticia == null)
            {
                return NotFound();
            }
            _data.Noticia.Remove(noticia);
            await _data.SaveChangesAsync();
            return RedirectToAction(nameof(Inicio));
        }

        private void ObtenerCategorias(object categoriaSeleccionada = null)
        {
            var categorias = _data.CategoriaNoticia
            .Select(s => new
            {
                ID = s.IdCategoriaNoticia,
                Nombre = s.Nombre
            });
            ViewBag.categorias = new SelectList(categorias.AsNoTracking(), "ID", "Nombre", categoriaSeleccionada);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}