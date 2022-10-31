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

namespace Aplicacion.UmbralesMinPh
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMinPhDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMinPhDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMinPhDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralMinPh = await _context.UmbralMinPh
                    .Select(u => new ListarUmbralMinPhDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralMinPh;
            }
        }
    }
}
