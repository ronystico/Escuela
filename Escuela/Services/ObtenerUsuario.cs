using System.Collections.Generic;
using System.Linq;
using Escuela.Data;
using Escuela.Models;
using Escuela.Models.ViewModels;

namespace Escuela.Services
{
    public class ObtenerUsuario
    {
        private readonly ApplicationDbContext _data;
        public ObtenerUsuario(ApplicationDbContext data)
        {
            _data = data;
        }
        public IQueryable<UsuarioViewModel> ObtenerTodosLosUsuariosConRol(){
            return (from usuario in _data.Users
                            join asociacionrol in _data.UserRoles on usuario.Id equals asociacionrol.UserId
                            join nombrerol in _data.Roles on asociacionrol.RoleId equals nombrerol.Id
                            select new UsuarioViewModel
                            {
                                Id = usuario.Id,
                                PrimerApellido = usuario.PrimerApellido,
                                SegundoApellido = usuario.SegundoApellido,
                                Nombres = usuario.Nombres,
                                UserName = usuario.UserName,
                                IdentityRole = nombrerol,
                                Estado = usuario.Estado
                            });
        } 
    }
}