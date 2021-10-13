using Microsoft.AspNetCore.Identity;

namespace Escuela.Models.ViewModels
{
    public class DetalleEstudianteViewModel : ApplicationUser
    {
        public IdentityRole IdentityRole { get; set; }

        public Padres Padres { get; set; }
    }
}