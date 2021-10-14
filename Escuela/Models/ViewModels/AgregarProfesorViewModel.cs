using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Escuela.Models.ViewModels
{
    public class AgregarProfesorViewModel : DetalleProfesorCursosAsignatura
    {
        new public List<int> IdDetalleCursosAsignatura { get; set; }
    }
}
