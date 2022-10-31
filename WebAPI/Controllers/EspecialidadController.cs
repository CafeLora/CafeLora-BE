using Aplicacion.Especialidades;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class EspecialidadController : MiControllerBase
    {
        [HttpGet("lista/{rol}")]
        public async Task<ActionResult<List<Especialidad>>> DevolverEspecialidadPorRol(string rol)
        {
            return await Mediator.Send(new Consulta.Listar { Rol = rol });
        }
    }
}
