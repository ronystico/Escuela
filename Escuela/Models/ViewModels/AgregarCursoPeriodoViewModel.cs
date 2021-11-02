using System.Collections.Generic;
using System.ComponentModel;

namespace Escuela.Models.ViewModels
{
    public class AgregarCursoPeriodoViewModel : DetalleCursoPeriodo
    {
        [DisplayName("Asignaturas")]
        public List<int> AsignaturasSeleccionadas { get; set; }
        public int IdAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public bool Seleccionado { get; set; }
    }
}
