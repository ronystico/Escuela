using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models.ViewModels
{
    public class CursoPeriodoAsignaturaViewModel
    {
        public DetalleCursoPeriodo DetalleCursoPeriodo { get; set; }
        public DetalleCursoperiodoAsignatura DetalleCursoperiodoAsignatura { get; set; }
        public List<int> AsignaturasSeleccionadas { get; set; }
    }
}
