using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("curso")]
    public class Curso
    {
        [Key]
        [Column("id_curso",Order = 0)]
        public int IdCurso { get; set; }
        
        [Column("nombre")]
        [StringLength(50)]
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "Falta el campo Nombre")]
        public string Nombre { get; set; }

        [Column("seccion")]
        [Required(ErrorMessage = "Falta el campo Sección")]
        [DisplayName("Sección")]
        [StringLength(10)]
        public string Seccion { get; set; }

        public virtual ICollection<DetalleCursoPeriodo> DetalleCursoPeriodo { get; set; }
    }
}