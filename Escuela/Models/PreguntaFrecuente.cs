using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("pregunta_frecuente")]
    public class PreguntaFrecuente
    {
        [Key]
        [Column("id_pregunta_frecuente")]
        public int IdPreguntaFrecuente { get; set; }

        [Column("pregunta")]
        [Required(ErrorMessage = "Falta el campo: Pregunta")]
        [StringLength(500)]
        public string Pregunta { get; set; }

        [Column("respuesta")]
        [Required(ErrorMessage = "Falta el campo: Respuesta")]
        [StringLength(4000)]
        public string Respuesta { get; set; }
    }
}