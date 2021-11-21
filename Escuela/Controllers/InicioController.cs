using Escuela.Data;
using Escuela.Models;
using Escuela.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    public class InicioController : Controller
    {
        private readonly ILogger<InicioController> _logger;

        private readonly ApplicationDbContext _data;
        private readonly UserManager<ApplicationUser> _user;

        public InicioController(ILogger<InicioController> logger, ApplicationDbContext data, UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _data = data;
            _user = user;
        }

        [AllowAnonymous]
        public IActionResult Inicio()
        {
            var imagenesActuales = _data.Carousel.OrderBy(s => s.IdImagen).ToList();
            ViewBag.noticias = _data.Noticia
            .Include(s => s.CategoriaNoticia)
            .Include(s => s.ApplicationUser)
            .AsNoTracking()
            .OrderByDescending(s => s.FechaPublicacion)
            .Take(3)
            .ToList();
            
            ViewBag.idnuevo = imagenesActuales.Count + 1;
            var imagenesActualesModelo = new List<InicioCarouselViewModel>();
            foreach (var imagenActual in imagenesActuales)
            {
                imagenesActualesModelo.Add(new InicioCarouselViewModel
                {
                    IdCarousel = imagenActual.IdCarousel,
                    IdImagen = imagenActual.IdImagen,
                    Imagen = imagenActual.Imagen,
                });
            }
            return View(imagenesActualesModelo);
        }

        [AllowAnonymous]
        public IActionResult Acercade()
        {
            return View();
        }

        public IActionResult VermiInformacion()
        {
            var roles = ((ClaimsIdentity)User.Identity).Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value);

            var rol = roles.FirstOrDefault();

            if (rol != null)
            {
                return rol switch
                {
                    "Estudiante" =>
                        RedirectToAction("Inicio", "Calificaciones",
                        new { area = "Estudiante" }),
                    "Administracion" =>
                       RedirectToAction("Inicio", "Usuario",
                       new { area = "Administracion" }),
                    "Profesor" =>
                       RedirectToAction("Inicio", "Calificacion",
                       new { area = "Profesor" }),
                    _ =>
                    View()
                };
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
