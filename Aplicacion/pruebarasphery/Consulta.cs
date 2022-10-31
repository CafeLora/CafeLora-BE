using Aplicacion.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using Persistencia.DapperConexion.Paginacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.pruebarasphery
{
    public class Consulta
    {
        public class Listar : IRequest<PaginacionModel>
        {
            public int NumeroPagina { get; set; }
            public int CantidadElementos { get; set; }

            public Dictionary<string, object> Parametros { get; set; } = new Dictionary<string, object>();
            //   public Dictionary<string, object> Parametros { get; set; } = new Dictionary<string, object>();
        }

        public class Manejador : IRequestHandler<Listar, PaginacionModel>
        {

            private readonly IPaginacion _paginacion;
            public Manejador(IPaginacion paginacion)
            {
                _paginacion = paginacion;
            }
            public async Task<PaginacionModel> Handle(Listar request, CancellationToken cancellationToken)
            {
                var storedProcedure = "usp_obtener_paginacion_sensor";
                return await _paginacion.devolverPaginacion(
                    storedProcedure,
                    request.NumeroPagina,
                    request.CantidadElementos,
                     request.Parametros,
                    //ordenamiento
                    null
                );
            }
        }
    }
}