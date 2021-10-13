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

        [Column("id_curso")]
        [Required(ErrorMessage = "Falta el campo: IdCurso")]
        public int IdCurso { get; set; }

        [Column("numero_de_orden")]
        [Required(ErrorMessage = "Falta el campo: Numero de Orden")]
        [DisplayName("Número de Orden")]
        public int NumerodeOrden { get; set; }

        [Column("id_padres")]
        public int? IdPadres { get; set; }

        [Column("id_o_rne")]
        [DisplayName("ID o RNE")]
        public string IdoRNE { get; set; }
        
        public virtual ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("IdCurso")]
        public virtual Curso Curso { get; set; }

        [ForeignKey("IdPadres")]
        public virtual Padres Padres { get; set; }
    }
}