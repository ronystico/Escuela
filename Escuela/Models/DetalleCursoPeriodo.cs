using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("detalle_curso_periodo")]
    public class DetalleCursoPeriodo
    {
        [Key]
        [Column("id_detalle_curso_periodo")]
        public int IdDetalleCursoPeriodo { get; set; }

        [Column("id_curso")]
        [Required(ErrorMessage = "Falta el campo: ID Curso")]
        [DisplayName("Curso/Sección")]
        public int IdCurso { get; set; }

        [Column("id_periodo")]
        [DisplayName("Periodo/Subperiodo")]
        [Required(ErrorMessage = "Falta el campo: ID Periodo")]
        public int IdPeriodo { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }

        [ForeignKey("IdPeriodo")]
        public Periodo Periodo { get; set; }

        public ICollection<DetalleCursoperiodoAsignatura> DetalleCursoperiodoAsignatura { get; set; }
    }
}