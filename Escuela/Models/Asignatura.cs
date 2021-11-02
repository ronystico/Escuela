using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace Escuela.Models
{
    [Table("asignatura")]
    public class Asignatura
    {
        [Key]
        [Column("id_asignatura",Order = 0)]
        public int IdAsignatura { get; set; }

        [Column("nombre")]
        [Required(ErrorMessage = "Falta el campo: Nombre")]
        [DisplayName("Nombre")]
        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<DetalleCursoperiodoAsignatura> DetalleCursoperiodoAsignatura { get; set; }
    }
}