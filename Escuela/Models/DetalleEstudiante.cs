using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("detalle_estudiante")]
    public class DetalleEstudiante
    {
        [Key,ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        [Column("id_detalle_curso_periodo")]
        [Required(ErrorMessage = "Falta el campo: IdDetalleCursoPeriodo")]
        [DisplayName("Periodo/Subperiodo - Curso/Seccion")]
        public int IdDetalleCursoPeriodo { get; set; }

        [Column("numero_de_orden")]
        [Required(ErrorMessage = "Falta el campo: Numero de Orden")]
        [DisplayName("Número de Orden")]
        public int NumerodeOrden { get; set; }

        [Column("id_padres")]
        public int? IdPadres { get; set; }

        [Column("id_o_rne")]
        [DisplayName("ID o RNE")]
        [StringLength(13)]
        public string IdoRNE { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("IdDetalleCursoPeriodo")]
        public virtual DetalleCursoPeriodo DetalleCursoPeriodo { get; set; }

        [ForeignKey("IdPadres")]
        public virtual Padres Padres { get; set; }
    }
}