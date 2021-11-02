using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("calificacion")]
    public class Calificacion
    {
        [Key]
        [Column("id_calificacion")]
        public int IdCalificacion { get; set; }

        [Column("id_estudiante")]
        public string IdEstudiante { get; set; }

        [Column("id_profesor")]
        public string IdProfesor { get; set; }
        
        [Column("id_detallecursoperiodo_asignatura")]
        public int IdDetalleCursoPeriodoAsignatura { get; set; }

        [Column("fecha_asignada")]
        public DateTime FechaAsignada { get; set; }

        [Column("fecha_editada")]
        public DateTime FechaEditada { get; set; }

        [Column("calificacion_total")]
        [DisplayName("Calificación Total")]
        public int CalificacionTotal { get; set; }

        [Column("observacion")]
        [StringLength(1000)]
        [DisplayName("Observación")]
        public string Observacion { get; set; }

        [ForeignKey("IdEstudiante")]
        public virtual ApplicationUser ApplicationUserEstudiante { get; set; }

        [ForeignKey("IdProfesor")]
        public virtual ApplicationUser ApplicationUserProfesor { get; set; }

        [ForeignKey("IdDetalleCursoPeriodoAsignatura")]
        public virtual DetalleCursoperiodoAsignatura DetalleCursoperiodoAsignatura { get; set; }
    }
}