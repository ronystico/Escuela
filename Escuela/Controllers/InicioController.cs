using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                        RedirectToAction("Inicio", "Usuario",
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
