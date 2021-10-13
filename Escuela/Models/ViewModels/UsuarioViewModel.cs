using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Escuela.Models.ViewModels
{
    public class UsuarioViewModel : ApplicationUser
    {
        [Required(ErrorMessage = "Falta el campo: Nombre de Usuario")]
        [DisplayName("Nombre de Usuario")]
        new public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La {0} debe ser de al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        public IdentityRole IdentityRole { get; set; }
    }
}