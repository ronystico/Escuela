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

        public async Task<IActionResult> Inicio(string ordenarPor,string cadenaDeBusqueda,
        string filtroActual, int? numeroDePagina)
        {
            ObtenerUsuario usuarios = new ObtenerUsuario(_data);
            var listaUsuarios = usuarios.ObtenerTodosLosUsuariosConRol();

            ViewData["NombresOrdenar"] = string.IsNullOrEmpty(ordenarPor) ? "NombreDescendiente" : "";
            ViewData["PrimerApellidoOrdenar"] = ordenarPor == "PrimerApellido" ? "PrimerApellidoDescendiente" : "PrimerApellido";
            ViewData["SegundoApellidoOrdenar"] = ordenarPor == "SegundoApellido" ? "SegundoApellidoDescendiente" : "SegundoApellido";
            ViewData["EstadoOrdenar"] = ordenarPor == "Estado" ? "EstadoDescendiente" : "Estado";
            ViewData["FiltroActual"] = cadenaDeBusqueda;
            ViewData["OrdenarActual"] = filtroActual;

            if(cadenaDeBusqueda != null){
                numeroDePagina = 1;
            }
            else{
                cadenaDeBusqueda = filtroActual;
            }

            if(!string.IsNullOrEmpty(cadenaDeBusqueda)){
                listaUsuarios = listaUsuarios.Where(s => s.Nombres.Contains(cadenaDeBusqueda) ||
                s.PrimerApellido.Contains(cadenaDeBusqueda) || s.SegundoApellido.Contains(cadenaDeBusqueda) ||
                s.UserName.Contains(cadenaDeBusqueda));
            }

            switch(ordenarPor){
                case "NombreDescendiente":
                listaUsuarios = listaUsuarios.OrderByDescending(s => s.Nombres);
                break;
                case "PrimerApellido":
                listaUsuarios = listaUsuarios.OrderBy(s => s.PrimerApellido);
                break;
                case "PrimerApellidoDescendiente":
                listaUsuarios = listaUsuarios.OrderByDescending(s => s.PrimerApellido);
                break;
                case "SegundoApellido":
                listaUsuarios = listaUsuarios.OrderBy(s => s.SegundoApellido);
                break;
                case "SegundoApellidoDescendiente":
                listaUsuarios = listaUsuarios.OrderByDescending(s => s.SegundoApellido);
                break;
                case "Estado":
                listaUsuarios = listaUsuarios.OrderBy(s => s.Estado);
                break;
                case "EstadoDescendiente":
                listaUsuarios = listaUsuarios.OrderByDescending(s => s.Estado);
                break;
                default:
                listaUsuarios = listaUsuarios.OrderBy(s => s.Nombres);
                break;
            }

            int cantidadPorPagina = 10;
            return View(await PaginatedList<UsuarioViewModel>.CreateAsync(listaUsuarios.AsNoTracking(),numeroDePagina ?? 1,cantidadPorPagina));
        }

        public IActionResult Agregar()
        {
            ObtenerDatos datos = new ObtenerDatos(_data);
            ViewBag.Roles = datos.ObtenerRoles();

            return View(new UsuarioViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid && 
                (usuario.IdentityRole.Name.Equals("Estudiante") ||
                usuario.IdentityRole.Name.Equals("Profesor") ||
                usuario.IdentityRole.Name.Equals("Administracion")))
            {
                var user = new ApplicationUser
                {
                    UserName = usuario.UserName,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido,
                    Nombres = usuario.Nombres,
                    Estado = "Inscrito",
                    FechaAgregado = System.DateTime.Now
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
                        };;
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
                }
            }
            ObtenerDatos roles = new ObtenerDatos(_data);
            ViewBag.roles = roles.ObtenerRoles();

            return View(usuario);
        }

        public async Task<IActionResult> AgregarEstudiante(string id, int id2)
        {
            if(string.IsNullOrEmpty(id)){
                return NotFound();
            }
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
                Padres padrevacio = new Padres();
                ViewBag.padres = padrevacio;
            }
            ObtenerCursosPeriodos();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarEstudiante(string id, AgregarEstudianteViewModel estudiante)
        {
            if(string.IsNullOrEmpty(id)){
                return UnprocessableEntity();
            }
            if(estudiante.DetalleEstudiante.IdDetalleCursoPeriodo == 0){
                    ModelState.AddModelError("DetalleEstudiante.IdDetalleCursoPeriodo","Por favor, agrega algún Periodo/Curso para asignarlo al estudiante");
                }
            if(await _data.DetalleEstudiante.AnyAsync(s => s.NumerodeOrden == estudiante.DetalleEstudiante.NumerodeOrden &&
            s.IdDetalleCursoPeriodo == estudiante.DetalleEstudiante.IdDetalleCursoPeriodo))
            {
                ModelState.AddModelError("DetalleEstudiante.NumerodeOrden", "Este número de orden ya existe en el Periodo/Curso seleccionado. Por favor, vaya a Periodos/Cursos/Asignaturas y revise la lista de estudiantes");
            }
            if (ModelState.IsValid)
            {
                DetalleEstudiante detalles = new DetalleEstudiante();
                if (estudiante.DetalleEstudiante.IdPadres == 0)
                {
                    detalles = new DetalleEstudiante()
                    {
                        UserId = id,
                        IdDetalleCursoPeriodo = estudiante.DetalleEstudiante.IdDetalleCursoPeriodo,
                        NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden,
                        IdEstudiante = estudiante.DetalleEstudiante.IdEstudiante,
                        RNE = estudiante.DetalleEstudiante.RNE
                    };
                }
                else
                {
                    detalles = new DetalleEstudiante()
                    {
                        UserId = id,
                        IdDetalleCursoPeriodo = estudiante.DetalleEstudiante.IdDetalleCursoPeriodo,
                        NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden,
                        IdPadres = estudiante.DetalleEstudiante.IdPadres,
                        IdEstudiante = estudiante.DetalleEstudiante.IdEstudiante,
                        RNE = estudiante.DetalleEstudiante.RNE
                    };
                }
                var resultado = await _data.DetalleEstudiante.AddAsync(detalles);
                await _data.SaveChangesAsync();
                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }

            if(string.IsNullOrEmpty(id)){
                return NotFound();
            }
            ViewBag.user = await _userManager.FindByIdAsync(id);
            ViewBag.id = id;
            int? id2 = estudiante.DetalleEstudiante.IdPadres ?? 0;
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
                Padres padrevacio = new Padres();
                ViewBag.padres = padrevacio;
            }
            ObtenerCursosPeriodos();
            return View(estudiante);
        }

        public async Task<IActionResult> AgregarProfesor(string id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var usuario = await _userManager.FindByIdAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(usuario);
            if (!roles.Contains("Profesor"))
            {
                return NotFound();
            }
            ViewBag.id = id;
            ObtenerAsignaturas();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProfesor(AgregarProfesorViewModel profesor, string id)
        {
            if (ModelState.IsValid)
            {
                if (profesor.IdDetalleCursoperiodoAsignatura != null)
                {
                    var eliminarExistente = _data.DetalleProfesorCursoperiodoAsignatura.Where(a => a.UserId == id);
                    _data.RemoveRange(eliminarExistente);

                    List<DetalleProfesorCursoperiodoAsignatura> asignaturasProfesor = new List<DetalleProfesorCursoperiodoAsignatura>();
                    foreach (var cursoAsignaturaSeleccionada in profesor.IdDetalleCursoperiodoAsignatura)
                    {
                        asignaturasProfesor.Add(new DetalleProfesorCursoperiodoAsignatura
                        {
                            UserId = id,
                            IdDetalleCursoperiodoAsignatura = cursoAsignaturaSeleccionada
                        });
                    }
                    await _data.AddRangeAsync(asignaturasProfesor);
                    await _data.SaveChangesAsync();
                }
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
            ViewBag.referencia = referencia;
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
            if (id == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            ViewBag.roles = roles[0];
            var profesor = await _data.Users
                .Include(a => a.DetalleProfesorCursoperiodoAsignatura)
                .ThenInclude(a => a.DetalleCursoperiodoAsignatura)
                .ThenInclude(a => a.Asignatura)
                .Include(a => a.DetalleProfesorCursoperiodoAsignatura)
                .ThenInclude(a => a.DetalleCursoperiodoAsignatura)
                .ThenInclude(a => a.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleProfesorCursoperiodoAsignatura)
                .ThenInclude(s => s.DetalleCursoperiodoAsignatura)
                .ThenInclude(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();
            return View(profesor);
        }

        public async Task<IActionResult> DetalleEstudiante(string id, int? id2)
        {
            if (id == null)
            {
                return NotFound();
            }
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(id));
            ViewBag.roles = roles[0];

            var estudiante = await _data.Users.Where(s => s.Id == id)
                .Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleEstudiante)
                .ThenInclude(s => s.Padres)
                .FirstOrDefaultAsync();
            if (estudiante.DetalleEstudiante == null)
            {
                return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id, id2 = id2 });
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
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.id = id;
            var estudiante = await _userManager.FindByIdAsync(id);

            if (id2 != null)
            {
                await _data.Entry(estudiante).Reference(s => s.DetalleEstudiante).LoadAsync();
                if (estudiante.DetalleEstudiante == null)
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
                if (estudiante.DetalleEstudiante == null)
                {
                    return RedirectToAction("AgregarEstudiante", "Usuario", new { area = "Administracion", id = id });
                }
                await _data.Entry(estudiante.DetalleEstudiante).Reference(s => s.Padres).LoadAsync();
                if (estudiante.DetalleEstudiante.Padres == null)
                {
                    estudiante.DetalleEstudiante.Padres = new Padres { };
                }
            }

            CursoPeriodoEstudiante(estudiante);
            return View(estudiante);
        }

        [HttpPost]
        public async Task<IActionResult> EditarEstudiante(ApplicationUser estudiante)
        {
            if (await _data.DetalleEstudiante.AnyAsync(s => s.NumerodeOrden == estudiante.DetalleEstudiante.NumerodeOrden &&
             s.IdDetalleCursoPeriodo == estudiante.DetalleEstudiante.IdDetalleCursoPeriodo))
            {
                ModelState.AddModelError("DetalleEstudiante.NumerodeOrden", "Este número de orden ya existe en el Periodo/Curso seleccionado. Por favor, vaya a Periodos/Cursos/Asignaturas y revise la lista de estudiantes");
            }
            if (ModelState.IsValid && (estudiante.Estado.Equals("Inscrito") || estudiante.Estado.Equals("Retirado")))
            {
                var usuario = await _userManager.FindByIdAsync(estudiante.Id);
                var detalleEstudiante = _data.DetalleEstudiante.Find(estudiante.Id);

                usuario.Nombres = estudiante.Nombres;
                usuario.PrimerApellido = estudiante.PrimerApellido;
                usuario.SegundoApellido = estudiante.SegundoApellido;
                usuario.UserName = estudiante.UserName;
                usuario.Estado = estudiante.Estado;

                detalleEstudiante.IdDetalleCursoPeriodo = estudiante.DetalleEstudiante.IdDetalleCursoPeriodo;
                detalleEstudiante.IdEstudiante = estudiante.DetalleEstudiante.IdEstudiante;
                detalleEstudiante.RNE = estudiante.DetalleEstudiante.RNE;

                if (estudiante.DetalleEstudiante.Padres.IdPadres != 0)
                {
                    detalleEstudiante.IdPadres = estudiante.DetalleEstudiante.Padres.IdPadres;
                }
                detalleEstudiante.NumerodeOrden = estudiante.DetalleEstudiante.NumerodeOrden;

                await _userManager.UpdateAsync(usuario);

                _data.DetalleEstudiante.Update(detalleEstudiante);
                await _data.SaveChangesAsync();

                return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
            }

            CursoPeriodoEstudiante(estudiante);

            return View(estudiante);
        }

        public async Task<IActionResult> EditarProfesor(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var usuario = await _userManager.FindByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewBag.nombres = usuario.Nombres + " " + usuario.PrimerApellido + " " + usuario.SegundoApellido;
            ViewBag.id = id;
            await _data.Entry(usuario).Collection(s => s.DetalleProfesorCursoperiodoAsignatura).LoadAsync();

            EditarAsignaturasProfesor(usuario);
            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProfesor(ApplicationUser profesor, AgregarProfesorViewModel asignaturas, string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var profesorObtenido = await _userManager.FindByIdAsync(id);
            if (profesorObtenido == null)
            {
                return NotFound();
            }
            await _data.Entry(profesorObtenido).Collection(s => s.DetalleProfesorCursoperiodoAsignatura).LoadAsync();
            if (ModelState.IsValid && (profesor.Estado.Equals("Inscrito") || profesor.Estado.Equals("Retirado")))
            {
                profesorObtenido.Nombres = profesor.Nombres;
                profesorObtenido.PrimerApellido = profesor.PrimerApellido;
                profesorObtenido.SegundoApellido = profesor.SegundoApellido;
                profesorObtenido.UserName = profesor.UserName;
                profesorObtenido.Estado = profesor.Estado;

                var eliminarExistente = _data.DetalleProfesorCursoperiodoAsignatura.Where(a => a.UserId == id);
                _data.RemoveRange(eliminarExistente);

                List<DetalleProfesorCursoperiodoAsignatura> asignaturasProfesor = new List<DetalleProfesorCursoperiodoAsignatura>();

                if (asignaturas.IdDetalleCursoperiodoAsignatura != null)
                {
                    foreach (var IdDetalleCursoperiodoAsignatura in asignaturas.IdDetalleCursoperiodoAsignatura)
                    {
                        asignaturasProfesor.Add(new DetalleProfesorCursoperiodoAsignatura
                        {
                            UserId = id,
                            IdDetalleCursoperiodoAsignatura = IdDetalleCursoperiodoAsignatura
                        });
                    }
                    await _data.AddRangeAsync(asignaturasProfesor);
                    await _data.SaveChangesAsync();
                }

                await _userManager.UpdateAsync(profesorObtenido);
                await _data.SaveChangesAsync();
                return RedirectToAction("DetalleProfesor", "Usuario", new { area = "Administracion", id = id });
            }
            var funcionaporfavor = await _userManager.FindByIdAsync(id);
            await _data.Entry(funcionaporfavor).Collection(s => s.DetalleProfesorCursoperiodoAsignatura).LoadAsync();
            EditarAsignaturasProfesor(funcionaporfavor);
            return View(profesor);
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
                    foreach (var error in resultado.Errors)
                    {
                        if (error.Code.Equals("PasswordRequiresDigit"))
                        {
                            ModelState.AddModelError(string.Empty, "La contraseña requiere al menos un número");
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

        [AllowAnonymous]
        public async Task<IActionResult> PrimerUsuario()
        {
            IList<ApplicationUser> usuariosEnRol = await _userManager.GetUsersInRoleAsync("Administracion");
            if (usuariosEnRol.Count > 0)
            {
                return Forbid();
            }
            return View(new UsuarioViewModel());
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PrimerUsuario(UsuarioViewModel usuario)
        {
            IList<ApplicationUser> usuariosEnRol = await _userManager.GetUsersInRoleAsync("Administracion");
            if (usuariosEnRol.Count > 0)
            {
                return Forbid();
            }
            if (ModelState.IsValid && usuario.IdentityRole.Name.Equals("Administracion"))
            {
                var user = new ApplicationUser
                {
                    UserName = usuario.UserName,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido,
                    Nombres = usuario.Nombres,
                    Estado = "Inscrito",
                    FechaAgregado = System.DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, usuario.Password);
                if (result.Succeeded)
                {
                    var usuarioCreado = await _userManager.FindByNameAsync(user.UserName);
                    var resultadoRol = await _userManager.AddToRoleAsync(usuarioCreado, "Administracion");
                    if (resultadoRol.Succeeded)
                    {
                        return RedirectToAction("Inicio", "Usuario", new { area = "Administracion" });
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
                }
            }
            return View(usuario);
        }

        // Obtener Cursos y Periodos
        private void ObtenerCursosPeriodos(object cursoPeriodo = null)
        {
            var cursosPeriodos = _data.DetalleCursoPeriodo
                .Include(s => s.Periodo)
                .Include(s => s.Curso)
                .Select(s => new
                {
                    ID = s.IdDetalleCursoPeriodo,
                    Nombre = s.Periodo.Nombre + " / " + s.Periodo.Subperiodo + " - " + s.Curso.Nombre + " / " + s.Curso.Seccion
                });
            ViewBag.cursosperiodos = new SelectList(cursosPeriodos.AsNoTracking(), "ID", "Nombre", cursoPeriodo);
        }

        // Obtener Cursos y Periodos de estudiante
        private void CursoPeriodoEstudiante(ApplicationUser estudiante)
        {
            var cursosPeriodos = _data.DetalleCursoPeriodo
                .Include(s => s.Periodo)
                .Include(s => s.Curso)
                .Select(s => new
                {
                    ID = s.IdDetalleCursoPeriodo,
                    Nombre = s.Periodo.Nombre + " / " + s.Periodo.Subperiodo + " - " + s.Curso.Nombre + " / " + s.Curso.Seccion
                });

            var cursoPeriodoEstudiante = new HashSet<int> { estudiante.DetalleEstudiante.IdDetalleCursoPeriodo };

            var cursoPeriodoListo = new List<EditarEstudianteViewModel>();
            foreach (var cursoPeriodo in cursosPeriodos)
            {
                cursoPeriodoListo.Add(new EditarEstudianteViewModel
                {
                    IdDetalleCursoPeriodo = cursoPeriodo.ID,
                    Nombre = cursoPeriodo.Nombre,
                    Seleccionado = cursoPeriodoEstudiante.Contains(cursoPeriodo.ID)
                });
            }
            ViewData["CursoPeriodo"] = cursoPeriodoListo;
        }

        // Obtener asignaturas para los profesores
        private void ObtenerAsignaturas(object asignatura = null)
        {
            var asignaturasObtenidas = _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .OrderBy(s => s.DetalleCursoPeriodo.Periodo.Nombre)
                .ThenBy(s => s.DetalleCursoPeriodo.Curso.Nombre)
                .ThenBy(s => s.DetalleCursoPeriodo.Curso.Seccion)
                .ThenBy(s => s.Asignatura.Nombre)
                .Select(s => new
                {
                    ID = s.IdDetalleCursoperiodoAsignatura,
                    Nombre = s.DetalleCursoPeriodo.Periodo.Nombre + " / " + s.DetalleCursoPeriodo.Periodo.Subperiodo
                + " - " +
                s.DetalleCursoPeriodo.Curso.Nombre + " / " + s.DetalleCursoPeriodo.Curso.Seccion
                + " - " +
                s.Asignatura.Nombre
                });
            ViewBag.asignaturas = new SelectList(asignaturasObtenidas, "ID", "Nombre", asignatura);
        }

        // Asignaturas para editar de un profesor
        private void EditarAsignaturasProfesor(ApplicationUser profesor)
        {
            var asignaturasObtenidas = _data.DetalleCursoperiodoAsignatura
                .Include(s => s.Asignatura)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Curso)
                .Include(s => s.DetalleCursoPeriodo)
                .ThenInclude(s => s.Periodo)
                .OrderBy(s => s.DetalleCursoPeriodo.Periodo.Nombre)
                .ThenBy(s => s.DetalleCursoPeriodo.Curso.Nombre)
                .ThenBy(s => s.DetalleCursoPeriodo.Curso.Seccion)
                .ThenBy(s => s.Asignatura.Nombre)
                .Select(s => new
                {
                    ID = s.IdDetalleCursoperiodoAsignatura,
                    Nombre = s.DetalleCursoPeriodo.Periodo.Nombre + " / " + s.DetalleCursoPeriodo.Periodo.Subperiodo
                + " - " +
                s.DetalleCursoPeriodo.Curso.Nombre + " / " + s.DetalleCursoPeriodo.Curso.Seccion
                + " - " +
                s.Asignatura.Nombre
                });

            var asignaturasProfesor = new HashSet<int>(profesor.DetalleProfesorCursoperiodoAsignatura.Select(s => s.IdDetalleCursoperiodoAsignatura));
            var asignaturasListas = new List<AgregarProfesorViewModel>();
            foreach (var asignatura in asignaturasObtenidas)
            {
                asignaturasListas.Add(new AgregarProfesorViewModel
                {
                    IDAsignatura = asignatura.ID,
                    Nombre = asignatura.Nombre,
                    Seleccionado = asignaturasProfesor.Contains(asignatura.ID)
                });
            }
            ViewData["Asignaturas"] = asignaturasListas;
        }
    }
}