using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models.ViewModels
{
    public class CursoAsignaturaViewModel
    {
        public Curso Curso { get; set; }
        public DetalleCursosAsignatura DetalleCursosAsignatura { get; set; }
        public List<int> AsignaturasSeleccionadas { get; set; }
    }
}
