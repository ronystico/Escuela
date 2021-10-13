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
        public string Nombre { get; set; }

        public virtual ICollection<DetalleCursosAsignatura> DetalleCursosAsignatura { get; set; }
    }
}