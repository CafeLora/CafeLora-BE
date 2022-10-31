
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Aplicacion.ManejadorError;
using System.Net;
using System;
using Microsoft.AspNetCore.Identity;

namespace Aplicacion.Seguridad
{
    public class RolNuevo
    {
        public class Ejecuta : IRequest
        {
            public string Nombre { get; set; }
        }

        public class ValidaEjecuta : AbstractValidator<Ejecuta>
        {
            public ValidaEjecuta()
            {
                RuleFor(x => x.Nombre).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly RoleManager<IdentityRole> _rolManager;
            public Manejador(RoleManager<IdentityRole> rolManager)
            {
                _rolManager = rolManager;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var rol = await _rolManager.FindByNameAsync(request.Nombre);
                if (rol != null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { message = "El rol ya existe" });
                }

                var result = await _rolManager.CreateAsync(new IdentityRole(request.Nombre));
                if (result.Succeeded)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo guardar el rol");
            }
        }
    }
}