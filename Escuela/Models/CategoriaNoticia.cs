using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models
{
    [Table("categoria_noticia")]
    public class CategoriaNoticia
    {
        [Key]
        [Column("id_categoria_noticia")]
        public int IdCategoriaNoticia { get; set; }
        
        [Required(ErrorMessage = "Falta el campo: Nombre")]
        [DisplayName("Nombre")]
        [StringLength(50)]
        public string Nombre { get; set; }

        public ICollection<Noticia> Noticia { get; set; }
    }
}