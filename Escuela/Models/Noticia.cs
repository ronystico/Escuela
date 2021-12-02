using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("noticia")]
    public class Noticia
    {
        [Key]
        [Column("id_noticia")]
        public int IdNoticia { get; set; }

        [Column("id_categoria_noticia")]
        public int IdCategoriaNoticia { get; set; }

        [Column("id_autor")]
        public string IdAutor { get; set; }

        [Column("titulo")]
        [DisplayName("Título")]
        [Required(ErrorMessage = "Falta el campo: Título")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Column("cuerpo")]
        [DisplayName("Cuerpo")]
        [Required(ErrorMessage = "Falta el campo: Cuerpo")]
        public string Cuerpo { get; set; }

        [Column("fecha_publicacion")]
        public DateTime FechaPublicacion { get; set; }

        [Column("fecha_edicion")]
        public DateTime FechaEdicion { get; set; }

        [ForeignKey("IdCategoriaNoticia")]
        public CategoriaNoticia CategoriaNoticia { get; set; }

        [ForeignKey("IdAutor")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}