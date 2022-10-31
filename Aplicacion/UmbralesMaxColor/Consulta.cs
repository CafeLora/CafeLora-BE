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

namespace Aplicacion.UmbralesMaxColor
{
    public class Consulta
    {
        public class Listar : IRequest<List<ListarUmbralMaxColorDto>>
        {
            public string UserRol { get; set; }
        }

        public class Manejador : IRequestHandler<Listar, List<ListarUmbralMaxColorDto>>
        {
            private readonly CafeLoraContext _context;
            public Manejador(CafeLoraContext context)
            {
                _context = context;
            }
            public async Task<List<ListarUmbralMaxColorDto>> Handle(Listar request, CancellationToken cancellationToken)
            {
                var umbralmaxColor = await _context.UmbralMaxColor
                    .Select(u => new ListarUmbralMaxColorDto
                    {
                        Id = u.Id,
                        Ultimo = u.Ultimo,
                    })
                    .ToListAsync();

                return umbralmaxColor;
            }
        }
    }
}
