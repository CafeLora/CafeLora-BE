using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Seguridad
{
    public class UsuarioListar
    {
        public class ListarUsuarios : IRequest<List<UsuarioData>> 
        {
            public string Rol { get; set; }
        }
        public class Manejador : IRequestHandler<ListarUsuarios, List<UsuarioData>>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly CafeLoraContext _context;
            public Manejador(UserManager<Usuario> userManager, CafeLoraContext context)
            {
                _userManager = userManager;
                _context = context;
            }

            public async Task<List<UsuarioData>> Handle(ListarUsuarios request, CancellationToken cancellationToken)
            {
                var usuarios = await _userManager.GetUsersInRoleAsync(request.Rol);
                var usuarioData = new List<UsuarioData>();

                foreach (var usuario in usuarios) 
                {
                    var especialidad = usuario.EspecialidadId != null ? await  _context.Especialidad.FindAsync(usuario.EspecialidadId) : null;

                    usuarioData.Add(new UsuarioData
                    {   
                        Id = usuario.Id,
                        Codigo = usuario.Codigo,
                        Especialidad = especialidad != null ? especialidad.Descripcion : null,
                        Nombre = usuario.Nombres + ' ' + usuario.Apellidos,
                        Nombres = usuario.Nombres,
                        Apellidos = usuario.Apellidos,
                        Email = usuario.Email,
                        PhoneNumber = usuario.PhoneNumber,
                        FechaNacimiento = usuario.FechaNacimiento,
                        Username = usuario.UserName,
                        Rol = request.Rol,
                        Entity = "usuario"
                    });
                }
                return usuarioData;

            }
        }
    }
}
