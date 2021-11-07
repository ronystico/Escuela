using System.Collections.Generic;

namespace Escuela.Models.ViewModels
{
    public class AgregarEditarCalificacionesViewModel
    {
        public List<DetalleCursoperiodoAsignatura> DetalleCursoperiodoAsignatura { get; set; }
        public List<Calificacion> Calificacion { get; set; }
    }
}