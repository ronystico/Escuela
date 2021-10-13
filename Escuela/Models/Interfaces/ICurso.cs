using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Escuela.Models.Interfaces
{
    public interface ICurso
    {
         IActionResult Inicio();
         IActionResult Agregar();
         IActionResult Agregar(Curso Curso);

    }
}