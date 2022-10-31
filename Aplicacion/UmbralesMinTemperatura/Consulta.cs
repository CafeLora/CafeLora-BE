using Aplicacion.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UmbralesMinTemperatura
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMinTempDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMinTempDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMinTempDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralmintemperatura = await _context.UmbralMinTemperatura
                    .Select(u => new ListarUmbralMinTempDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralmintemperatura;
            }
        }
    }
}
