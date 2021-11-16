using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Escuela.Models.ViewModels
{
    public class InicioCarouselViewModel
    {
        public int IdCarousel { get; set; }
        [Required(ErrorMessage = "Falta el campo: IdImagen")]
        public int IdImagen { get; set; }
        [Required(ErrorMessage = "Falta el campo: Imagen")]
        public byte[] Imagen { get; set; }

        public IFormFile ImagenParaSubir { get; set; }
    }
}
