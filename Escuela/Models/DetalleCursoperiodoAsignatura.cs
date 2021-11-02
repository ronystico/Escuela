using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("detalle_cursoperiodo_asignatura")]
    public class DetalleCursoperiodoAsignatura
    {
        [Key]
        [Column("id_detalle_cursoperiodo_asignatura", Order = 0)]
        public int IdDetalleCursoperiodoAsignatura { get; set; }

        [Column("id_detalle_curso_periodo")]
        public int IdDetalleCursoPeriodo { get; set; }

        [Column("id_asignatura")]
        public int IdAsignatura { get; set; }

        [ForeignKey("IdDetalleCursoPeriodo")]
        public DetalleCursoPeriodo DetalleCursoPeriodo { get; set; }

        [ForeignKey("IdAsignatura")]
        public Asignatura Asignatura { get; set; }

        public virtual ICollection<DetalleProfesorCursoperiodoAsignatura> DetalleProfesorCursoperiodoAsignatura { get; set; }
    }
}