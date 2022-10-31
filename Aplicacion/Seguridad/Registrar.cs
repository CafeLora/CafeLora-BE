using System;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Constants;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Seguridad
{
    public class Registrar
    {
        public class Ejecuta : IRequest<UsuarioData>
        {
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public string Password { get; set; }

            public string Token { get; set; }
            public string Email { get; set; }
            public string Username { get; set; }
            public string Imagen { get; set; }
            public string Rol { get; set; }
            public string PhoneNumber { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public string Especialidad { get; set; }
        }

        public class EjecutaValidador : AbstractValidator<Ejecuta>
        {
            public EjecutaValidador()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }

        }

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly CafeLoraContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly RoleManager<IdentityRole> _roleManager;

            public Manejador(
                CafeLoraContext context,
                UserManager<Usuario> userManager,
                RoleManager<IdentityRole> roleManager,
                IJwtGenerador jwtGenerador)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _roleManager = roleManager;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rol = await _roleManager.FindByNameAsync(request.Rol);
                if (rol == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El rol no existe" });
                }


                var existe = await _context.Users.Where(x => x.Email == request.Email).AnyAsync();
                if (existe)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "El email ingresado ya existe" });
                }

                var existeUsername = await _context.Users.Where(x => x.UserName == request.Username).AnyAsync();
                if (existeUsername)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { mensaje = "El nombre de usuario ingresado ya existe" });
                }

                var lastUserInRolCodigo = _userManager.GetUsersInRoleAsync(request.Rol).Result.OrderByDescending(ev => ev.Codigo).FirstOrDefault().Codigo;

                var codigoGenerado = "";
                var codigoPrefijo = "";

                switch (rol.Name)
                {
                    case "Analistas": codigoPrefijo = EntityCodes.Analistas; break;
                    case "Administrador": codigoPrefijo = EntityCodes.Administrador; break;
                    case "Jefe de riesgos": codigoPrefijo = EntityCodes.Jefe_de_riesgos; break;
                    case "Alta gerencia": codigoPrefijo = EntityCodes.Alta_gerencia; break;
                    case "Especialistas": codigoPrefijo = EntityCodes.Especialista; break;
                }

                if (lastUserInRolCodigo == null)
                {
                    codigoGenerado = codigoPrefijo + "001";
                }
                else
                {
                    string substr = lastUserInRolCodigo.Substring(2, 3);
                    codigoGenerado = codigoPrefijo + (int.Parse(substr) + 1).ToString().PadLeft(substr.Length, '0');
                }

                var especialidad = _context.Especialidad.Where(x => x.Descripcion == request.Especialidad).FirstOrDefault();
        

                var usuario = new Usuario
                {
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    Email = request.Email,
                    UserName = request.Nombres + request.Apellidos,
                    Foto = request.Imagen,
                    PhoneNumber = request.PhoneNumber,
                    FechaNacimiento = request.FechaNacimiento,
                    Codigo = codigoGenerado,
                    EspecialidadId = especialidad?.Id,
                };

                Regex sWhitespace = new Regex(@"\s+");

                usuario.UserName = Regex.Replace(usuario.UserName, @"\s+", "");

                // LLamar a metodo para insertar usuario
                var result = await _userManager.CreateAsync(usuario, request.Password);

                if (result.Succeeded)
                {

                    var userCreated = await _userManager.FindByNameAsync(Regex.Replace(usuario.UserName, @"\s+", ""));

                    var user = await _userManager.AddToRoleAsync(userCreated, request.Rol);

                    if (user.Succeeded)
                    {

                        return new UsuarioData
                        {
                            Nombres = usuario.Nombres,
                            Apellidos = usuario.Apellidos,
                            Token = _jwtGenerador.CrearToken(usuario, null),
                            Username = usuario.UserName,
                            Email = usuario.Email
                        };

                        throw new Exception("No se pudo agregar al nuevo usuario");
                    }

                }

                throw new Exception("No se pudo agregar al nuevo usuario");
            }
        }
    }
}