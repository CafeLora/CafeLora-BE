using Aplicacion.Dtos;
using Aplicacion.UmbralesMaxColor;
using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class UmbralMaxColorController : MiControllerBase
    {
        [HttpGet("lista")]
        public async Task<ActionResult<List<ListarUmbralMaxColorDto>>> Listar()
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
