using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models.ViewModels
{
    public class AgregarProfesorViewModel
    {
        public int IDAsignatura { get; set; }
        public string Nombre { get; set; }
        public bool Seleccionado { get; set; }
        public List<int> IdDetalleCursoperiodoAsignatura { get; set; }
    }
}
