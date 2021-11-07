using System.Collections.Generic;

namespace Escuela.Models.ViewModels
{
    public class AgregarEditarCalificacionViewModel
    {
        public List<DetalleCursoperiodoAsignatura> DetalleCursoperiodoAsignatura { get; set; }
        public Calificacion Calificacion { get; set; }
    }
}