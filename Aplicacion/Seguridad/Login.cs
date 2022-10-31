using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class Login
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta> // validar que los datos de login no sean nulos
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            private readonly IJwtGenerador _jwtGenerador;
            public Manejador(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, IJwtGenerador jwtGenerador)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerador = jwtGenerador;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, new { usuario = "Correo o contraseña incorrecto" });
                }

                var result = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                var listaRoles = new List<string>(resultadoRoles);

                if (result.Succeeded)
                {
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
                    };
                }

                throw new ManejadorExcepcion(HttpStatusCode.Unauthorized, new { usuario = "Correo o contraseña incorrecto" });
            }
        }
    }
}