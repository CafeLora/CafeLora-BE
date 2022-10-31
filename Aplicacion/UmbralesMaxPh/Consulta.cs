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

namespace Aplicacion.UmbralesMaxPh
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMaxPhDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMaxPhDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMaxPhDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralmaxPh = await _context.UmbralMaxPh
                    .Select(u => new ListarUmbralMaxPhDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralmaxPh;
            }
        }
    }
}
