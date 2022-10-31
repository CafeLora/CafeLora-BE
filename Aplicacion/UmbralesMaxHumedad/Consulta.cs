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

namespace Aplicacion.UmbralesMaxHumedad
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMaxHumedadDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMaxHumedadDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMaxHumedadDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralmaxhumedad= await _context.UmbralMaxHumedad
                    .Select(u => new ListarUmbralMaxHumedadDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralmaxhumedad;
            }
        }
    }
}
