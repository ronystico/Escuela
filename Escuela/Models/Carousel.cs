using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("carousel")]
    public class Carousel
    {
        [Key]
        [Column("id_carousel")]
        public int IdCarousel { get; set; }
        [Column("id_imagen")]
        [Required(ErrorMessage = "Falta el campo: IdImagen")]
        public int IdImagen { get; set; }
        [Column("imagen")]
        [Required(ErrorMessage = "Falta el campo: Imagen")]
        public byte[] Imagen { get; set; }
    }
}