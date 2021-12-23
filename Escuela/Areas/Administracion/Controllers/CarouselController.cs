using Escuela.Data;
using Escuela.Models;
using Escuela.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Controllers
{
    [Area("Administracion")]
    [Authorize(Roles = "Administracion")]
    public class CarouselController : Controller
    {
        private string[] extensionesPermitidas = { ".jpeg", ".jpg", ".png" };
        private readonly Dictionary<string, List<byte[]>> numerosMagicos = new Dictionary<string, List<byte[]>>{
            {".jpeg", new List<byte[]>{
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
            }
            },
            {".jpg", new List<byte[]>{
                new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
            new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
            }
            },
            {
                ".png", new List<byte[]>{
                    new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A }
                }
            }
        };
        private readonly ApplicationDbContext _data;
        public CarouselController(ApplicationDbContext data)
        {
            _data = data;
        }
        public IActionResult Inicio()
        {
            var imagenesActuales = _data.Carousel.AsNoTracking().OrderBy(s => s.IdImagen).ToList();
            ViewBag.idnuevo = imagenesActuales.Count + 1;
            var imagenesActualesModelo = new List<InicioCarouselViewModel>();
            foreach (var imagenActual in imagenesActuales)
            {
                imagenesActualesModelo.Add(new InicioCarouselViewModel
                {
                    IdCarousel = imagenActual.IdCarousel,
                    IdImagen = imagenActual.IdImagen,
                    Imagen = imagenActual.Imagen
                });
            }
            return View(imagenesActualesModelo);
        }

        public IActionResult Agregar()
        {
            ViewBag.cantidadexistente = _data.Carousel.Count();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Agregar(InicioCarouselViewModel imagenRecibida)
        {
            Carousel imagenValidada = await ValidarArchivo(imagenRecibida);
            if (imagenValidada.Imagen != null)
            {
                await _data.Carousel.AddAsync(imagenValidada);
                await _data.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }

            ViewBag.cantidadexistente = _data.Carousel.Count();
            return View(imagenRecibida);
        }

        public IActionResult Editar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var imagenaEditar = _data.Carousel.Where(s => s.IdImagen == id - 1).FirstOrDefault();
            if (imagenaEditar == null)
            {
                return NotFound();
            }

            ViewBag.imagenactual = id;
            var imagenaEditarModelo = new InicioCarouselViewModel
            {
                IdCarousel = imagenaEditar.IdCarousel,
                IdImagen = imagenaEditar.IdImagen,
                Imagen = imagenaEditar.Imagen
            };
            return View(imagenaEditarModelo);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, InicioCarouselViewModel imagenRecibida)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var imagenaEditar = _data.Carousel.Where(s => s.IdImagen == id - 1).FirstOrDefault();
            if (imagenaEditar == null)
            {
                return NotFound();
            }

            Carousel imagenValidada = await ValidarArchivo(imagenRecibida);
            if (imagenValidada.Imagen != null)
            {
                imagenaEditar.Imagen = imagenValidada.Imagen;
                _data.Carousel.Update(imagenaEditar);
                await _data.SaveChangesAsync();
                return RedirectToAction(nameof(Inicio));
            }

            ViewBag.imagenactual = id;
            var imagenaEditarModelo = new InicioCarouselViewModel
            {
                IdCarousel = imagenaEditar.IdCarousel,
                IdImagen = imagenaEditar.IdImagen,
                Imagen = imagenaEditar.Imagen
            };
            return View(imagenaEditarModelo);
        }

        public IActionResult Eliminar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var imagenaEliminar = _data.Carousel.Where(s => s.IdImagen == id - 1).FirstOrDefault();
            if (imagenaEliminar == null)
            {
                return NotFound();
            }

            ViewBag.imagenactual = id;
            var imagenaEliminarModelo = new InicioCarouselViewModel
            {
                IdCarousel = imagenaEliminar.IdCarousel,
                IdImagen = imagenaEliminar.IdImagen,
                Imagen = imagenaEliminar.Imagen
            };
            return View(imagenaEliminarModelo);
        }

        [HttpPost, ActionName("Eliminar")]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            int idReal = id - 1;
            var imagenaEliminar = _data.Carousel.Where(s => s.IdImagen == idReal).FirstOrDefault();
            if (imagenaEliminar == null)
            {
                return NotFound();
            }
            else
            {
                _data.Carousel.Remove(imagenaEliminar);

                var elementosaReordenar = _data.Carousel.Where(s => s.IdImagen > idReal).ToList();
                elementosaReordenar.ForEach(s => s.IdImagen -= 1);
                _data.UpdateRange(elementosaReordenar);

                await _data.SaveChangesAsync();

                return RedirectToAction(nameof(Inicio));
            }
        }

        private async Task<Carousel> ValidarArchivo(InicioCarouselViewModel imagenRecibida)
        {
            using (var memoryStream = new MemoryStream())
            {
                await imagenRecibida.ImagenParaSubir.CopyToAsync(memoryStream);

                if (memoryStream.Length < 2097152)
                {
                    var extension = Path.GetExtension(imagenRecibida.ImagenParaSubir.FileName).ToLowerInvariant();

                    if (string.IsNullOrEmpty(extension) || !extensionesPermitidas.Contains(extension))
                    {
                        ModelState.AddModelError("Imagen", "La extensión del archivo es inválida");
                    }
                    else
                    {
                        bool numeroMagicoValido;
                        using (var reader = new BinaryReader(memoryStream))
                        {
                            var signatures = numerosMagicos[extension];
                            reader.BaseStream.Position = 0;
                            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

                            numeroMagicoValido = signatures.Any(signature =>
                                headerBytes.Take(signature.Length).SequenceEqual(signature));
                        }
                        if (numeroMagicoValido)
                        {
                            int cantidadExistente = _data.Carousel.Count();
                            return new Carousel()
                            {
                                IdImagen = cantidadExistente,
                                Imagen = memoryStream.ToArray()
                            };
                        }
                        else
                        {
                            ModelState.AddModelError("Imagen", "El número mágico del archivo es inválido");
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("Imagen", "El archivo supera los 2 MB");
                }
            }
            return new Carousel();
        }
    }
}
