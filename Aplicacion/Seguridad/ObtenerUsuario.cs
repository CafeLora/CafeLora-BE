using Aplicacion.Contratos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Seguridad
{
    public class ObtenerUsuario
    {
        public class Ejecuta : IRequest<UsuarioData> 
        { 
            public string userId { get; set; }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly CafeLoraContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;
            public Manejador(UserManager<Usuario> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion, CafeLoraContext context)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
                _context = context;
            }

            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByIdAsync(request.userId);
                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);
                var especialidad = await _context.Especialidad.FindAsync(usuario.EspecialidadId);

                return new UsuarioData
                {
                    Nombres = usuario.Nombres,
                    Apellidos = usuario.Apellidos,
                    Token = _jwtGenerador.CrearToken(usuario, listaRoles),
                    Username = usuario.UserName,
                    Email = usuario.Email,
                    Imagen = null,
                    Rol = listaRoles.Count > 0 ? listaRoles[0] : null,
                    PhoneNumber = usuario.PhoneNumber,
                    FechaNacimiento = usuario.FechaNacimiento,
                    Codigo = usuario.Codigo,
                    Especialidad = especialidad?.Descripcion
                };
            }
        }
    }
}
