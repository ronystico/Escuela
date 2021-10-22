using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    public class ApplicationUser : IdentityUser
    {
        // primer apellido
        [Column("primer_apellido")]
        [Required(ErrorMessage = "Falta el campo: Primer apellido")]
        [DisplayName("Primer Apellido")]
        [StringLength(50)]
        public string PrimerApellido { get; set; }

        // segundo apellido
        [Column("segundo_apellido")]
        [Required(ErrorMessage = "Falta el campo: Segundo apellido")]
        [DisplayName("Segundo Apellido")]
        [StringLength(50)]
        public string SegundoApellido { get; set; }

        [Column("nombres")]
        [Required(ErrorMessage = "Falta el campo: Nombres")]
        [DisplayName("Nombres")]
        [StringLength(100)]
        public string Nombres { get; set; }

        // estado: Inscrito/Retirado
        [Column("estado")]
        [Required(ErrorMessage = "Falta el campo: Estado")]
        [DisplayName("Estado")]
        [StringLength(10)]
        public string Estado { get; set; }

        [Column("fecha_agregado")]
        [Required(ErrorMessage = "Falta el campo: Fecha Agregado")]
        [DisplayName("Fecha Agregado")]
        public DateTime FechaAgregado { get; set; }

        public virtual DetalleEstudiante DetalleEstudiante { get; set; }

        public virtual ICollection<DetalleProfesorCursosAsignatura> DetalleProfesorCursosAsignatura { get; set; }
    }
}
