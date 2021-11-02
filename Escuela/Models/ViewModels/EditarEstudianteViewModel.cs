using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models.ViewModels
{
    public class EditarEstudianteViewModel
    {
        public int IdDetalleCursoPeriodo { get; set; }
        public string Nombre { get; set; }
        public bool Seleccionado { get; set; }
    }
}
