using Aplicacion.Dtos;
using Aplicacion.UmbralesMaxHumedad;
using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UmbralMaxHumedadController : MiControllerBase
    {
        [HttpGet("lista")]
        public async Task<ActionResult<List<ListarUmbralMaxHumedadDto>>> Listar()
        {
            return await Mediator.Send(new Consulta.Listar());
        }

        [HttpPost]
        public async Task<ActionResult<Nuevo.Ejecuta>> RegistrarUmbral(Nuevo.Ejecuta parametros)
        {
            return await Mediator.Send(parametros);
        }
    }
}
