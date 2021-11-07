using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("periodo")]
    public class Periodo : IValidatableObject
    {
        [Key]
        [Column("id_periodo")]
        public int IdPeriodo { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "Falta el campo: Nombre")]
        [DisplayName("Nombre")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Column("subperiodo")]
        [Required(ErrorMessage = "Falta el campo: Subperiodo")]
        [DisplayName("Subperiodo")]
        [StringLength(100)]
        public string Subperiodo { get; set; }

        [Column("fecha_inicio")]
        [DisplayName("Fecha de Inicio")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        [DisplayName("Fecha de Fin")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime FechaFin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(FechaFin < FechaInicio)
            {
                yield return new ValidationResult(
                    errorMessage: "FechaFin debe ser mayor a FechaInicio",
                    memberNames: new[] { "FechaFin" });
            }
        }

        public virtual ICollection<DetalleCursoPeriodo> DetalleCursoPeriodo { get; set; }
    }
}