using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Escuela.Models.ViewModels
{
    public class UsuarioViewModel : ApplicationUser
    {
        public UsuarioViewModel()
        {
            this.FechaAgregado = DateTime.Now;
        }

        [Required(ErrorMessage = "Falta el campo: Nombre de Usuario")]
        [DisplayName("Nombre de Usuario")]
        new public string UserName { get; set; }

        [Required(ErrorMessage = "Falta el campo: Clave")]
        [StringLength(100, ErrorMessage = "La {0} debe ser de al menos {2} y un máximo de {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Clave")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Clave")]
        [Compare("Password", ErrorMessage = "La clave y clave de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Falta el campo: Fecha Agregado")]
        [DisplayName("Fecha Agregado")]
        [DataType(DataType.Text)]
        new public DateTime FechaAgregado { get; set; }

        public IdentityRole IdentityRole { get; set; }
    }
}