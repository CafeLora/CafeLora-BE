using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Dtos;
using Aplicacion.Paginacion;
using Aplicacion.Seguridad;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistencia.DapperConexion.Paginacion;
using Seguridad;

namespace WebAPI.Controllers
{
    public class UsuarioController : MiControllerBase
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta parametros)
        {   
            return await Mediator.Send(parametros);
        }

        [AllowAnonymous]
        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioData>> Registrar(Registrar.Ejecuta parametros)
        {
            return await Mediator.Send(parametros);
        }

        [HttpGet]
        public async Task<ActionResult<UsuarioData>> DevolverUsuario()
        {
            return await Mediator.Send(new UsuarioActual.Ejecuta());
        }

        [Authorize(Roles = "Administrador")] 
        [HttpGet("{id}")] 
        public async Task<ActionResult<UsuarioData>> ObtenerUsuarioPorId(string id)
        {
            return await Mediator.Send(new ObtenerUsuario.Ejecuta { userId = id });
        }

        //[Authorize(Roles = "Administrador")] // Unauthorized
        [HttpPut]
        public async Task<ActionResult<UsuarioData>> Actualizar(UsuarioActualizar.Ejecuta parametros)
        {
            return await Mediator.Send(parametros);
        }

        [Authorize(Roles = "Administrador")] // Forbidden
        [HttpDelete("{id}")] // Este metodo solo es potestad del administrador
        public async Task<ActionResult<Unit>> EliminarUsuario(string id)
        {
            return await Mediator.Send(new UsuarioEliminar.Ejecuta { Id = id });
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet("listar/{rol}")]
        public async Task<ActionResult<PaginacionModel>> ObtenerUsuariosPorRolPaginado(string rol, 
            [FromQuery(Name="page")] int page, [FromQuery(Name = "quantity")] int quantity)
        {
            return await Mediator.Send(new Paginacion.Ejecuta { Rol = rol, NumeroPagina = page, CantidadElementos = quantity, Entity = "Usuario" });
        }

        [HttpGet("lista/{rol}")]
        public async Task<ActionResult<List<ObtenerUsuarioListaDto>>> ObtenerUsuariosPorRol(string rol)
        {
            return await Mediator.Send(new Consulta.Listar { Rol = rol });
        }
    }
}