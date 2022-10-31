using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Aplicacion.Constants;
using Aplicacion.Contratos;
using Aplicacion.ManejadorError;
using Aplicacion.Seguridad;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Seguridad
{
    public class UsuarioActualizar
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
            public DateTime? FechaNacimiento { get; set; }
            public string Especialidad { get; set; }
        }

        //public class EjecutaValidador : AbstractValidator<Ejecuta>
        //{
        //    public EjecutaValidador()
        //    {
        //        RuleFor(x => x.Nombres).NotEmpty();
        //        RuleFor(x => x.Apellidos).NotEmpty();
        //        RuleFor(x => x.Email).NotEmpty();
        //        RuleFor(x => x.Password).NotEmpty();
        //        RuleFor(x => x.Username).NotEmpty();
        //    }
        //}

        public class Manejador : IRequestHandler<Ejecuta, UsuarioData>
        {
            private readonly CafeLoraContext _context;
            private readonly UserManager<Usuario> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IPasswordHasher<Usuario> _passwordHasher;
            public Manejador(
                CafeLoraContext context,
                UserManager<Usuario> userManager,
                RoleManager<IdentityRole> roleManager,
                IJwtGenerador jwtGenerador,
                IPasswordHasher<Usuario> passwordHasher)
            {
                _context = context;
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _passwordHasher = passwordHasher;
                _roleManager = roleManager;
            }
            public async Task<UsuarioData> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rol = await _roleManager.FindByNameAsync(request.Rol);
                if (rol == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensajge = "El rol no existe" });
                }

                var usuario = await _userManager.FindByNameAsync(request.Username);
                if (usuario == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { mensaje = "El usuario no existe" });
                }

                var otherUserExist = await _context.Users.Where(x => x.Email == request.Email && x.UserName != request.Username).AnyAsync();
                if (otherUserExist)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.InternalServerError, new { mensaje = "Ya existe un usuario" });
                }

                var especialidad = request.Especialidad != null ? _context.Especialidad.Where(x => x.Descripcion == request.Especialidad).First() : null;

                var roles_usuario = (List<string>)await _userManager.GetRolesAsync(usuario);

                var codigoGenerado = "";

                if (roles_usuario.First() != request.Rol)
                {
                    var lastUserInRolCodigo = _userManager.GetUsersInRoleAsync(request.Rol).Result.OrderByDescending(ev => ev.Codigo).FirstOrDefault().Codigo;

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
                }

                usuario.Email = request.Email ?? usuario.Email;
                usuario.Nombres = request.Nombres ?? usuario.Nombres;
                usuario.Apellidos = request.Apellidos ?? usuario.Apellidos;
                usuario.FechaNacimiento = request.FechaNacimiento ?? usuario.FechaNacimiento;
                usuario.PhoneNumber = request.PhoneNumber ?? usuario.PhoneNumber;
                if (request.Password != null) {
                    usuario.PasswordHash = _passwordHasher.HashPassword(usuario, request.Password);
                } else {
                    usuario.PasswordHash = usuario.PasswordHash;
                }
                usuario.UserName = request.Username ?? usuario.UserName;
                usuario.EspecialidadId = especialidad != null ? especialidad.Id : null;
                usuario.Codigo = codigoGenerado != "" ? codigoGenerado : usuario.Codigo;

                var rolesUsuario = await _userManager.GetRolesAsync(usuario);
                var removedRoles = await _userManager.RemoveFromRolesAsync(usuario, rolesUsuario);
                var result = await _userManager.AddToRoleAsync(usuario, request.Rol);

                var resultado = await _userManager.UpdateAsync(usuario);
                //var resultadoRoles = await _userManager.GetRolesAsync(usuario);
                //var listaRoles = new List<string>(resultadoRoles);
                var roles = new List<string>();
                roles.Add(rol.Name);

                if (resultado.Succeeded)
                {
                    return new UsuarioData
                    {
                        Email = usuario.Email,
                        Username = usuario.UserName,
                        Nombres = usuario.Nombres,
                        Apellidos = usuario.Apellidos,
                        Token = _jwtGenerador.CrearToken(usuario, roles)
                    };
                }

                throw new Exception("No se pudo actualizar usuario");
            }
        }
    }
}