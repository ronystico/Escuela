using System.Collections.Generic;

namespace Escuela.Models.ViewModels
{
    public class AgregarEditarCalificacionesViewModel
    {
        public DetalleCursoperiodoAsignatura DetalleCursoperiodoAsignatura { get; set; }
        public List<DetalleEstudiante> DetalleEstudiante { get; set; }
        public List<Calificacion> Calificacion { get; set; }
        public List<Calificacion> CalificacionNueva { get; set; }
    }
}