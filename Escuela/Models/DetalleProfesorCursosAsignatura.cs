using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("detalle_profesor_cursos_asignatura")]
    public class DetalleProfesorCursosAsignatura
    {
        [Key]
        [Column("id_detalle_profesor_cursos_asignatura")]
        public int IdDetalleProfesorCursosAsignatura { get; set; }

        [Column("UserId")]
        public string UserId { get; set; }

        [Column("id_detalle_cursos_asignatura")]
        public int IdDetalleCursosAsignatura { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("IdDetalleCursosAsignatura")]
        public DetalleCursosAsignatura DetalleCursosAsignatura { get; set; }
    }
}
