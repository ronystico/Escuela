using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escuela.Data;
using Escuela.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Escuela.Services;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Escuela.Models.ViewModels;

namespace Escuela.Areas.Administracion.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _data;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsuarioController(ApplicationDbContext data,
        UserManager<ApplicationUser> userManager)
        {
            _data = data;
            _userManager = userManager;
        }

        public IActionResult Inicio()
        {
            ObtenerUsuario usuarios = new ObtenerUsuario(_data);
            return View(usuarios.ObtenerTodosLosUsuariosConRol());
        }

        public IActionResult Agregar()
        {
            ObtenerDatos roles = new ObtenerDatos(_data);
            ViewBag.roles = roles.ObtenerRoles();

            return View();
        }

        // TODO: CRUD Padres
        // TODO: Editar Profesor
        // TODO: Marcar campos obligatorios y no obligatorios

        [HttpPost]
        public async Task<IActionResult> Agregar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = usuario.UserName,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido,
                    Nombres = usuario.Nombres,
                    Estado = "Inscrito"
                };
                var result = await _userManager.CreateAsync(user, usuario.Password);
                if (result.Succeeded)
                {
                    var usuarioCreado = await _userManager.FindByNameAsync(user.UserName);
                    var resultadoRol = await _userManager.AddToRoleAsync(usuarioCreado, usuario.IdentityRole.Name);
                    if (resultadoRol.Succeeded)
                    {
                        return usuario.IdentityRole.Name switch
                        {
                            "Estudiante" =>
                            RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = usuarioCreado.Id }),
                            "Profesor" =>
                            RedirectToAction("AgregarProfesor", "Usuario", new { area = "Administracion", id = usuarioCreado.Id }),
                            _ =>
                            RedirectToAction("Inicio", "Usuario", new { area = "Administracion" })
                        };
                        ;
                    }
                }
                else
                {

                }
                foreach (var error in result.Errors)
                {
                    if (error.Code.Equals("InvalidUserName"))
                    {
                        ModelState.AddModelError(string.Empty,
                        "El nombre de usuario es inválido, solo puede contener letras o números.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    ObtenerDatos roles = new ObtenerDatos(_data);
                    ViewBag.roles = roles.ObtenerRoles();
                }
            }
            return View(usuario);
        }

        public async Task<IActionResult> AgregarEstudiante(string id, int id2)
        {
            ObtenerDatos cursos = new ObtenerDatos(_data);
            ViewBag.cursos = cursos.ObtenerCursos();
            ViewBag.user = await _userManager.FindByIdAsync(id);
            ViewBag.id = id;
            if (id2 != 0)
            {
                var padres = await _data.Padres.FindAsync(id2);
                if (padres != null)
                {
                    ViewBag.padres = padres;
                }
            }
            else
            {
                Padres padrevacio = new Padres()
                {
                    //IdPadres = 0,
                    //NombresMadre = " ",
                    //PrimerApellidoMadre = " ",
                    //NombresPadre = " ",
                    //PrimerApellidoPadre = " "
                };
                ViewBag.padres = padrevacio;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEstudiante(AgregarEstudianteViewModel estudiante)
        {
            if (ModelState.IsValid)
            {
                DetalleEstudiante detalles = new DetalleEstudiante();
                if (estudiante.DetalleEstudiante.IdPadres == 0)
                {
                    detalles = new DetalleEstudiante()
                    {
                        UserId = estudiante.DetalleEstudiante.ApplicationUser.Id,
                        IdCurso = estudiante.DetalleEstudiante.IdCurso,
                        NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden,
                        IdoRNE = estudiante.DetalleEstudiante.IdoRNE
                    };
                }
                else
                {
                    detalles = new DetalleEstudiante()
                    {
                        UserId = estudiante.DetalleEstudiante.ApplicationUser.Id,
                        IdCurso = estudiante.DetalleEstudiante.IdCurso,
                        NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden,
                        IdPadres = estudiante.DetalleEstudiante.IdPadres,
                        IdoRNE = estudiante.DetalleEstudiante.IdoRNE
                    };
                }
                var resultado = await _data.DetalleEstudiante.AddAsync(detalles);
                await _data.SaveChangesAsync();
                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }
            return View(estudiante);
        }

        public IActionResult AgregarProfesor(string id)
        {
            ViewBag.id = id;
            ObtenerDatos datos = new ObtenerDatos(_data);
            ViewBag.cursosasignaturas = datos.ObtenerDetalleCursosAsignaturas();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProfesor(AgregarProfesorViewModel profesor)
        {
            if (ModelState.IsValid)
            {
                var eliminarExistente = _data.DetalleProfesorCursosAsignatura.Where(a => a.UserId == profesor.UserId);
                _data.RemoveRange(eliminarExistente);

                List<DetalleProfesorCursosAsignatura> asignaturasProfesor = new List<DetalleProfesorCursosAsignatura>();
                foreach (var cursoAsignaturaSeleccionada in profesor.IdDetalleCursosAsignatura)
                {
                    asignaturasProfesor.Add(new DetalleProfesorCursosAsignatura
                    {
                        UserId = profesor.UserId,
                        IdDetalleCursosAsignatura = cursoAsignaturaSeleccionada
                    });
                }
                await _data.AddRangeAsync(asignaturasProfesor);
                await _data.SaveChangesAsync();
                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }
            return View(profesor);
        }
        
        public IActionResult AgregarPadres(string id, string referencia)
        {
            ViewBag.id = id;
            ViewBag.referencia = referencia;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarPadres(string id, Padres padres, string referencia)
        {
            if (ModelState.IsValid)
            {
                var result = await _data.Padres.AddAsync(padres);
                _data.SaveChanges();
                if (referencia.Equals("EditarEstudiante"))
                {
                    return RedirectToAction("EditarEstudiante", "Usuario", new { area = "Administracion", id = id, id2 = result.Entity.IdPadres });
                }
                else
                {
                    return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id, id2 = result.Entity.IdPadres });
                }
            }
            return View(padres);
        }

        public IActionResult BuscarPadres(string id, string id2, string referencia)
        {
            ViewBag.id = id;
            ViewBag.id2 = id2;
            if (referencia != null)
            {
                ViewBag.referencia = referencia;
            }
            else
            {
                ViewBag.referencia = string.Empty;
            }
            var padres = _data.Padres.ToList();
            return View(padres);
        }

        public IActionResult Detalles(string id, string rol)
        {
            if (id != null && rol != null)
            {
                return rol switch
                {
                    "Estudiante" =>
                        RedirectToAction("DetalleEstudiante", "Usuario",
                        new { area = "Administracion", id = id }),
                    "Administracion" =>
                       RedirectToAction("DetalleAdministracion", "Usuario",
                       new { area = "Administracion", id = id }),
                    "Profesor" =>
                       RedirectToAction("DetalleProfesor", "Usuario",
                       new { area = "Administracion", id = id }),
                    _ =>
                    View()
                };
            }
            return View();
        }

        public async Task<IActionResult> DetalleProfesor(string id)
        {
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            ViewBag.roles = roles[0];
            var profesor = await _data.Users.Include(a => a.DetalleProfesorCursosAsignatura)
                .ThenInclude(a => a.DetalleCursosAsignatura)
                .ThenInclude(a => a.Asignatura)
                .Include(a => a.DetalleProfesorCursosAsignatura)
                .ThenInclude(a => a.DetalleCursosAsignatura)
                .ThenInclude(a => a.Curso)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            return View(profesor);
        }

        public async Task<IActionResult> DetalleEstudiante(string id)
        {
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            ViewBag.roles = roles[0];

            var estudiante = await _data.Users.Where(s => s.Id == id).Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.Curso).Include(s => s.DetalleEstudiante).ThenInclude(s => s.Padres)
                .FirstOrDefaultAsync();
            if (estudiante.DetalleEstudiante == null)
            {
                return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id });
            }
            if (estudiante.DetalleEstudiante.Padres == null)
            {
                estudiante.DetalleEstudiante.Padres = new Padres
                {

                };
            }
            return View(estudiante);
        }

        public async Task<IActionResult> DetalleAdministracion(string id)
        {
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            ViewBag.roles = roles[0];
            var administrador = await _data.Users.Where(s => s.Id == id).FirstOrDefaultAsync();
            return View(administrador);
        }

        public IActionResult Editar(string id, string rol)
        {
            if (id != null && rol != null)
            {
                return rol switch
                {
                    "Estudiante" =>
                        RedirectToAction("EditarEstudiante", "Usuario",
                        new { area = "Administracion", id = id }),
                    "Administracion" =>
                       RedirectToAction("EditarAdministracion", "Usuario",
                       new { area = "Administracion", id = id }),
                    "Profesor" =>
                       RedirectToAction("EditarProfesor", "Usuario",
                       new { area = "Administracion", id = id }),
                    _ =>
                    View()
                };
            }
                return View();
        }

        public async Task<IActionResult> EditarAdministracion(string id)
        {
            var administrador = await _data.Users.Where(s => s.Id == id).FirstOrDefaultAsync();
            return View(administrador);
        }

        [HttpPost]
        public async Task<IActionResult> EditarAdministracion(ApplicationUser user)
        {
            if (ModelState.IsValid && (user.Estado.Equals("Inscrito") || user.Estado.Equals("Retirado")))
            {
                var usuario = await _userManager.FindByIdAsync(user.Id);

                usuario.Nombres = user.Nombres;
                usuario.PrimerApellido = user.PrimerApellido;
                usuario.SegundoApellido = user.SegundoApellido;
                usuario.UserName = user.UserName;
                usuario.Estado = user.Estado;

                await _userManager.UpdateAsync(usuario);

                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }
            return View(user);
        }

        public async Task<IActionResult> EditarEstudiante(string id, int? id2)
        {
            var estudiante = await _userManager.FindByIdAsync(id);

            if (id2 != null)
            {
                await _data.Entry(estudiante).Reference(s => s.DetalleEstudiante).LoadAsync();
                if(estudiante.DetalleEstudiante == null)
                {
                    return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id });
                }
                var padres = await _data.Padres.FindAsync(id2);
                if (padres != null)
                {
                    estudiante.DetalleEstudiante.IdPadres = id2;
                    estudiante.DetalleEstudiante.Padres = padres;
                }
            }
            else
            {
                await _data.Entry(estudiante).Reference(s => s.DetalleEstudiante).LoadAsync();
                await _data.Entry(estudiante.DetalleEstudiante).Reference(s => s.Padres).LoadAsync();
                if (estudiante.DetalleEstudiante == null)
                {
                    return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id });
                }
                if (estudiante.DetalleEstudiante.Padres == null)
                {
                    estudiante.DetalleEstudiante.Padres = new Padres { };
                }
            }

            ObtenerDatos cursos = new ObtenerDatos(_data);
            ViewBag.cursos = cursos.ObtenerCursosEstudiante(id);
            return View(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstudiante(ApplicationUser estudiante)
        {
            if (ModelState.IsValid && (estudiante.Estado.Equals("Inscrito") || estudiante.Estado.Equals("Retirado")))
            {
                var usuario = await _userManager.FindByIdAsync(estudiante.Id);
                var detalleEstudiante = _data.DetalleEstudiante.Find(estudiante.Id);

                usuario.Nombres = estudiante.Nombres;
                usuario.PrimerApellido = estudiante.PrimerApellido;
                usuario.SegundoApellido = estudiante.SegundoApellido;
                usuario.UserName = estudiante.UserName;
                usuario.Estado = estudiante.Estado;

                detalleEstudiante.IdCurso = estudiante.DetalleEstudiante.IdCurso;
                detalleEstudiante.IdoRNE = estudiante.DetalleEstudiante.IdoRNE;
                detalleEstudiante.IdPadres = estudiante.DetalleEstudiante.Padres.IdPadres;
                detalleEstudiante.NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden;

                await _userManager.UpdateAsync(usuario);

                _data.DetalleEstudiante.Update(detalleEstudiante);
                await _data.SaveChangesAsync();

                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }
            ObtenerDatos cursos = new ObtenerDatos(_data);
            ViewBag.cursos = cursos.ObtenerCursosEstudiante(estudiante.Id);
            return View(estudiante);
        }
        
        public async Task<IActionResult> ReestablecerClave(string id)
        {
            var usuario = await _userManager.FindByIdAsync(id);
            var usuarioObtenido = new UsuarioViewModel()
            {
                Id = usuario.Id,
                UserName = usuario.UserName,
                Estado = usuario.Estado,
                Nombres = usuario.Nombres,
                PrimerApellido = usuario.PrimerApellido,
                SegundoApellido = usuario.SegundoApellido
            };
            return View(usuarioObtenido);
        }

        [HttpPost]
        public async Task<IActionResult> ReestablecerClave(UsuarioViewModel user)
        {
            if (ModelState.IsValid)
            {
                var usuario = await _userManager.FindByIdAsync(user.Id);
                var token = await _userManager.GeneratePasswordResetTokenAsync(usuario);
                var resultado = await _userManager.ResetPasswordAsync(usuario, token, user.Password);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
                }
                else
                {
                    foreach(var error in resultado.Errors)
                    {
                        if (error.Code.Equals("PasswordRequiresDigit"))
                        {
                            ModelState.AddModelError(string.Empty, "La contraseña debe tener al menos un número");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        
                    }
                }
                
            }
            return View(user);
        }

    }
}