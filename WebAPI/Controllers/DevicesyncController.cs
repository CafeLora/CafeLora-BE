using Aplicacion.Dtos;
using Aplicacion.devicesync;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistencia.DapperConexion.Paginacion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
namespace WebAPI.Controllers
{
    public class DevicesyncController : MiControllerBase
    {

        [HttpGet("listado")]
        public async Task<ActionResult<PaginacionModel>> Listar
      ([FromQuery(Name = "page")] int page, [FromQuery(Name = "quantity")] int quantity)
        {

            //return await Mediator.Send(new Consulta.Listar { QueryLike = filter });
            return await Mediator.Send(new Consulta.Listar
            {

                NumeroPagina = page,
                CantidadElementos = quantity

            });
        }



    }
}
