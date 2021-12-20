using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Models
{
    [Table("padres")]
    public class Padres
    {
        [Key]
        [Column("id_padres",Order = 0)]
        public int IdPadres { get; set; }

        [Column("primer_apellido_madre")]
        [StringLength(50)]
        [DisplayName("Primer Apellido de la Madre")]
        public string PrimerApellidoMadre { get; set; }

        [Column("segundo_apellido_madre")]
        [StringLength(50)]
        [DisplayName("Segundo Apellido de la Madre")]
        public string SegundoApellidoMadre { get; set; }

        [Column("nombres_madre")]
        [StringLength(50)]
        [Required(ErrorMessage = "Falta el campo: Nombres de la Madre")]
        [DisplayName("Nombres de la Madre")]
        public string NombresMadre { get; set; }

        [Column("telefono_madre")]
        [StringLength(20)]
        [DisplayName("Teléfono de la Madre")]
        public string TelefonoMadre { get; set; }

        // Padre
        [Column("primer_apellido_padre")]
        [StringLength(50)]
        [DisplayName("Primer Apellido del Padre")]
        public string PrimerApellidoPadre { get; set; }

        [Column("segundo_apellido_padre")]
        [StringLength(50)]
        [DisplayName("Segundo Apellido del Padre")]
        public string SegundoApellidoPadre { get; set; }

        [Column("nombres_padre")]
        [StringLength(50)]
        [Required(ErrorMessage = "Falta el campo: Nombres del Padre")]
        [DisplayName("Nombres del Padre")]
        public string NombresPadre { get; set; }

        [Column("telefono_padre")]
        [StringLength(20)]
        [DisplayName("Teléfono del Padre")]
        public string TelefonoPadre { get; set; }

        public ICollection<DetalleEstudiante> DetalleEstudiante { get; set; }
    }
}