using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("detalle_profesor_cursoperiodo_asignatura")]
    public class DetalleProfesorCursoperiodoAsignatura
    {
        [Key]
        [Column("id_detalle_profesor_cursoperiodo_asignatura")]
        public int IdDetalleProfesorCursoperiodoAsignatura { get; set; }

        [Column("UserId")]
        public string UserId { get; set; }

        [Column("id_detalle_cursoperiodo_asignatura")]
        public int IdDetalleCursoperiodoAsignatura { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("IdDetalleCursoperiodoAsignatura")]
        public DetalleCursoperiodoAsignatura DetalleCursoperiodoAsignatura { get; set; }
    }
}
