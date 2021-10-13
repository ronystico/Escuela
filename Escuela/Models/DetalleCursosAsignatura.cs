using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("detalle_cursos_asignatura")]
    public class DetalleCursosAsignatura
    {
        [Key]
        [Column("id_detalle_cursos_asignatura", Order = 0)]
        public int IdDetalleCursosAsignatura { get; set; }

        [Column("id_curso")]
        public int IdCurso { get; set; }

        [Column("id_asignatura")]
        public int IdAsignatura { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }

        [ForeignKey("IdAsignatura")]
        public Asignatura Asignatura { get; set; }

        public virtual ICollection<DetalleProfesorCursosAsignatura> DetalleProfesorCursosAsignatura { get; set; }
    }
}