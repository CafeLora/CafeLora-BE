using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Persistencia.DapperConexion.Paginacion;

namespace Aplicacion.Paginacion
{
    public class Paginacion
    {
        public class Ejecuta : IRequest<PaginacionModel>
        {
            //public string Titulo { get; set; } // filtrar por curso o cualquier propiedad (es dinamico)
            public string Rol { get; set; }
            public int NumeroPagina { get; set; }
            public int CantidadElementos { get; set; }
            public string? Entity { get; set; }
            public Dictionary<string, object> Parametros { get; set; } = new Dictionary<string, object>();
        }

        public class Manejador : IRequestHandler<Ejecuta, PaginacionModel>
        {
            private readonly IPaginacion _paginacion;
            public Manejador(IPaginacion paginacion)
            {
                _paginacion = paginacion;
            }
            public async Task<PaginacionModel> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var storedProcedure = "usp_obtener_paginacion_usuario";
                //var parametros = new Dictionary<string, object>();
                switch (request.Entity) 
                {
                    case "Usuario": 
                    {
                        storedProcedure = "usp_obtener_paginacion_usuario";
                        request.Parametros.Add("Rol", request.Rol);
                        break;
                    }
                    case "ListaVerificacion":
                    {
                        storedProcedure = "usp_obtener_paginacion_lista_verificacionV2";
                        break;
                    }
                }

                //var ordenamiento = "Titulo";
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
