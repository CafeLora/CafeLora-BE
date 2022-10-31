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

namespace Aplicacion.UmbralesMinHumedad
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMinHumedadDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMinHumedadDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMinHumedadDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralminhumedad = await _context.UmbralMinHumedad
                    .Select(u => new ListarUmbralMinHumedadDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralminhumedad;
            }
        }
    }
}
