using Aplicacion.ManejadorError;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Seguridad
{
    public class UsuarioEliminar
    {
        public class Ejecuta : IRequest
        {
            public string Id { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Manejador(UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
            {
                _userManager = userManager;
                _roleManager = roleManager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByIdAsync(request.Id);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El usuario no existe" });
                }

                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);

                var resultado = await _userManager.RemoveFromRolesAsync(usuario, listaRoles);
                if (resultado.Succeeded)
                {
                    var resultadoEliminarUsuario = await _userManager.DeleteAsync(usuario);

                    if (resultadoEliminarUsuario.Succeeded)
                    {
                        return Unit.Value;
                    }

                    throw new Exception("No se pudo eliminar al usuario");
                }

                throw new Exception("No se pudo eliminar al usuario");
            }
        }
    }
}
