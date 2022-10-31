using Aplicacion.Dtos;
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
    public class Consulta
    {
        public class Listar : IRequest<List<ObtenerUsuarioListaDto>>
        {
            public string Rol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ObtenerUsuarioListaDto>>
        {
            private readonly UserManager<Usuario> _userManager;
            public Manejador(UserManager<Usuario> userManager)
            {
                _userManager = userManager;
            }
            public async Task<List<ObtenerUsuarioListaDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var usuarios = await _userManager.GetUsersInRoleAsync(request.Rol);

                var usuarioData = new List<ObtenerUsuarioListaDto>();

                foreach (var usuario in usuarios)
                {
                    usuarioData.Add(new ObtenerUsuarioListaDto
                    {
                        UsuarioId = usuario.Id,
                        Apellidos = usuario.Apellidos,
                        Nombres = usuario.Nombres,
                        Codigo = usuario.Codigo,
                    });
                }

                return usuarioData;
            }
        }
    }
}
