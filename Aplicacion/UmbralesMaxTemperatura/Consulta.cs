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

namespace Aplicacion.UmbralesMaxTemperatura
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMaxTempDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMaxTempDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMaxTempDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralmaxtemperatura = await _context.UmbralMaxTemperatura
                    .Select(u => new ListarUmbralMaxTempDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralmaxtemperatura;
            }
        }
    }
}
